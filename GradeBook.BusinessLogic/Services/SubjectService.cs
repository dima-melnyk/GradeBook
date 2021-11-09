using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Models.Read;
using GradeBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IEntityRepository<Subject> _repository;
        private readonly IMapper _mapper;

        public SubjectService(IEntityRepository<Subject> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectModel>> GetSubjects() => (await _repository.GetAll().ToListAsync()).Select(_mapper.Map<SubjectModel>);

        public Task CreateSubject(Subject newSubject) => _repository.AddAsync(newSubject);
    }
}
