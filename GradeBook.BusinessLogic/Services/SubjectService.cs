using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Repository.Interfaces;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private IEntityRepository<Subject> _repository;

        public SubjectService(IEntityRepository<Subject> repository)
        {
            _repository = repository;
        }

        public async Task CreateSubject(Subject newSubject)
        {
            await _repository.AddAsync(newSubject);
        }
    }
}
