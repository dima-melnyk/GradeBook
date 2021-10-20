using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class TeacherManager : ITeacherManager
    {
        private readonly IEntityRepository<Teacher> _repository;
        private readonly IMapper _mapper;

        public TeacherManager(IEntityRepository<Teacher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task CreateTeacher(Teacher newTeacher) => _repository.AddAsync(newTeacher);

        public Task DeleteTeacher(int id) => _repository.RemoveByIdAsync(id);

        public async Task<TeacherToView> GetTeacher(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<TeacherToView>(model);
        }

    }
}
