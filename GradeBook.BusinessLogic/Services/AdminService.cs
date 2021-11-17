using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        private readonly GBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly List<string> _uniqueRoles = new List<string> { Role.Teacher.ToString(), Role.Pupil.ToString() };

        public AdminService(GBContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task UpdateRole(UpdateRole model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.Id);
            if (user == null)
                throw new ArgumentNullException(null, "User cannot be found");

            if (await IsRoleUnique(user, model.Role))
                throw new ArgumentException("User cannot be pupil and teacher simultaneously");

            if (model.Role == Role.Pupil) 
            {
                await _context.AddAsync(new UserClass() { Id = user.Id, ClassId = (int)model.ClassId });
                await _context.SaveChangesAsync();
            }

            await _userManager.AddToRoleAsync(user, model.Role.ToString());
        }

        public async Task<IEnumerable<UserModel>> GetUsers() => (await _userManager.Users.ToListAsync()).Select(GetUserModel);

        private UserModel GetUserModel(ApplicationUser user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Roles = _userManager.GetRolesAsync(user).Result;
            return model;
        }

        private async Task<bool> IsRoleUnique(ApplicationUser user, Role role) =>
            (await _userManager.GetRolesAsync(user)).Intersect(_uniqueRoles).Any() && _uniqueRoles.Contains(role.ToString());
    }
}
