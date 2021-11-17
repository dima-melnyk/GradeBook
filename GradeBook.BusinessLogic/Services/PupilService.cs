using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Repository.Interfaces;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using GradeBook.DataAccess.Entities.Base;
using GradeBook.DataAccess;
using System;

namespace GradeBook.BusinessLogic.Services
{
    public class PupilService : IPupilService
    {
        private readonly GBContext _context;
        private readonly IMapper _mapper;

        public PupilService(GBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task UpdatePupil(UserClass updatePupil)
        {
            _context.Update(updatePupil);
            await _context.SaveChangesAsync();
        }

        public async Task<PupilModel> GetPupil(int id)
        {
            var model = (await _context.Users.FirstOrDefaultAsync(u => u.Id == id)) ??
                throw new KeyNotFoundException("User cannot be found");

            var pupil = _mapper.Map<PupilModel>(model);
            var className = await (from cl in _context.Classes
                                   join uc in _context.UserClasses on cl.Id equals uc.ClassId
                                   join au in _context.Users on uc.Id equals au.Id
                                   where au.Id == id
                                   select cl.Name).FirstOrDefaultAsync();
            pupil.ClassName = className ?? throw new ArgumentException("User is not a pupil");

            return pupil;
        }

        public async Task<IEnumerable<PupilModel>> GetPupilsByClass(int classId) => await _context.Users
                .Join(_context.UserClasses.Where(uc => uc.ClassId == classId),
                    u => u.Id, uc => uc.Id, (u, uc) => _mapper.Map<PupilModel>(u))
                .ToListAsync();
    }
}
