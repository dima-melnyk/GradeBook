using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.BusinessLogic.Services
{
    public class TeacherManager : ITeacherManager
    {
        private readonly IEntityRepository<Teacher> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeacherManager(IEntityRepository<Teacher> repository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public Task DeleteTeacher(int id) => _repository.RemoveByIdAsync(id);

        public async Task<TeacherToView> GetTeacher(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<TeacherToView>(model);
        }

    }
}
