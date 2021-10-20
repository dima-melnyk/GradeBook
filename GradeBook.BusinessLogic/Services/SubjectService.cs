using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IEntityRepository<Subject> _repository;

        public SubjectService(IEntityRepository<Subject> repository)
        {
            _repository = repository;
        }

        public Task CreateSubject(Subject newSubject) => _repository.AddAsync(newSubject);
    }
}
