using AutoMapper;
using GradeBook.BusinessLogic.DTOs;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class ClassService : IClassService
    {
        private IEntityRepository<Class> _repository;
        private IMapper _mapper;

        public ClassService(IEntityRepository<Class> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateClass(CreateClassDTO newClass)
        {
            var model = _mapper.Map<Class>(newClass);
            await _repository.AddAsync(model);
        }

        public async Task DeleteClass(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(model);
        }

        public async Task<ClassDTO> GetClass(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClassDTO>(model);
        }
    }
}
