using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Models.Read;
using GradeBook.Repository.Interfaces;
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

        public IEnumerable<SubjectModel> GetSubjects() => _repository.GetAll().Select(_mapper.Map<SubjectModel>);

        public Task CreateSubject(Subject newSubject) => _repository.AddAsync(newSubject);
    }
}
