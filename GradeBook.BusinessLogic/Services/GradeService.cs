using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GradeBook.DataAccess;
using GradeBook.BusinessLogic.Constants;
using GradeBook.BusinessLogic.Extensions;

namespace GradeBook.BusinessLogic.Services
{
    public class GradeService : IGradeService
    {
        private readonly GBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEnumerable<string> _correctRoles = new List<string> { "Teacher", "Admin" };


        public GradeService(GBContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateGrade(Grade newGrade)
        {
            if (!(await _userManager.GetRolesAsync(await _userManager.Users.FirstOrDefaultAsync(u => u.Id == newGrade.PupilId)))
               .Contains(Role.Pupil.ToString()))
                throw new ArgumentException(Constants.Constants.ExceptionMessages.Grade.IncorrectRoleException);

            if (!(await IsPupilFromLessonClass(newGrade)))
                throw new ArgumentException(Constants.Constants.ExceptionMessages.Grade.IncorrectPupilException);

            await _context.AddAsync(newGrade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGrade(Grade updateGrade)
        {
            _context.Update(updateGrade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGrade(int id) 
        {
            _context.Remove(await _context.GetEntityById<Grade>(id));
            await _context.SaveChangesAsync();
        }

        public async Task<GradeModel> GetGrade(int id, IEnumerable<Claim> claims)
        {
            var model = await _context.GetEntityById<Grade>(id);

            var roles = claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                .Select(c => c.Value);

            var pupilId = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (!(pupilId == model.Pupil.Id || IsUserInCorrectRole(roles)))
                throw new MethodAccessException(Constants.Constants.ExceptionMessages.Grade.IllegalAccessException);
            return _mapper.Map<GradeModel>(model);
        }

        public async Task<IEnumerable<GradeModel>> GetGrades(GradeQuery query) => (await _context.Grades
                .Where(g => g.Pupil.Id == query.PupilId || query.PupilId == null)
                .Where(g => g.Lesson.SubjectId == query.SubjectId || query.SubjectId == null)
                .Where(g => g.Lesson.ClassId == query.ClassId || query.ClassId == null)
                .Where(g => g.Lesson.Date.Equals(query.Date) || query.Date == null)
                .ToListAsync())
                .Select(_mapper.Map<GradeModel>);

        private bool IsUserInCorrectRole(IEnumerable<string> roles) => _correctRoles.Intersect(roles).Any();
        private async Task<bool> IsPupilFromLessonClass(Grade grade) 
        {
            var pupilClassId = (await _context.GetEntityById<UserClass>(grade.PupilId)).ClassId;
            var lessonClassId = (await _context.GetEntityById<Lesson>(grade.LessonId)).ClassId;

            return pupilClassId == lessonClassId;
        }
    }
}
