using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities;
using GradeBook.DataAccess.Entities.Base;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.Repository.Interfaces;
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
        private readonly IEntityRepository<UserClass> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly List<string> _uniqueRoles = new List<string> { Role.Teacher.ToString(), Role.Pupil.ToString() };

        public AdminService(IEntityRepository<UserClass> repository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task UpdateRole(UpdateRole model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.Id);
            if (user == null)
                throw new KeyNotFoundException("User cannot be found");
            if (await IsRoleUnique(user, model.Role))
                throw new ArgumentException("User cannot be pupil and teacher simultaneously");

            if (model.Role == Role.Pupil)
                await _repository.AddAsync(new UserClass() { Id = user.Id, ClassId = (int)model.ClassId });

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
