using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Models;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class TeacherService : ITeacherService
    {
        private IEntityRepository<Teacher> _repository;
        private IMapper _mapper;

        public TeacherService(IEntityRepository<Teacher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateTeacher(Teacher newTeacher)
        {
            await _repository.AddAsync(newTeacher);
        }

        public async Task DeleteTeacher(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(model);
        }

        public async Task<TeacherToView> GetTeacher(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<TeacherToView>(model);
        }

    }
}
