using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities;
using GradeBook.DataAccess.Entities.Base;
using GradeBook.Models.Read;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public AdminService(GBContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Create<TEntity>(TEntity model) where TEntity: UserBase
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.Id);
            if (user == null)
                throw new KeyNotFoundException("User cannot be found");
            await _context.Set<TEntity>().AddAsync(model);
            await _context.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, model.GetType().Name);
        }

        public async Task<IEnumerable<UserModel>> GetUsers() => (await _userManager.Users.ToListAsync()).Select(GetUserModel);

        private UserModel GetUserModel(ApplicationUser user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Roles = _userManager.GetRolesAsync(user).Result;
            return model;
        }
    }
}
