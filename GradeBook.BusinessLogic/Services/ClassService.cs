using AutoMapper;
using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.BusinessLogic.Services
{
    public class ClassService : IClassService
    {
        private readonly IEntityRepository<Class> _repository;
        private readonly IMapper _mapper;

        public ClassService(IEntityRepository<Class> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task CreateClass(Class newClass) => _repository.AddAsync(newClass);

        public Task DeleteClass(int id) => _repository.RemoveByIdAsync(id);

        public async Task<ClassModel> GetClass(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClassModel>(model);
        }

        public async Task<IEnumerable<ClassModel>> GetClasses() => (await _repository.GetAll().ToListAsync()).Select(_mapper.Map<ClassModel>);
    }
}
