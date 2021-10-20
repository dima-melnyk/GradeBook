﻿using AutoMapper;
using GradeBook.BusinessLogic.Models;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;

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

        public async Task CreateClass(Class newClass)
        {
            await _repository.AddAsync(newClass);
        }

        public async Task DeleteClass(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(model);
        }

        public async Task<ClassToView> GetClass(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClassToView>(model);
        }
    }
}
