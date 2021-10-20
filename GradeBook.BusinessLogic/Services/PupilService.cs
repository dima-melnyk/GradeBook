using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Repository.Interfaces;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.BusinessLogic.Services
{
    public class PupilService : IPupilService
    {
        private readonly IEntityRepository<Pupil> _repository;
        private readonly IMapper _mapper;

        public PupilService(IEntityRepository<Pupil> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task CreatePupil(Pupil newPupil) => _repository.AddAsync(newPupil);

        public Task UpdatePupil(Pupil updatePupil) => _repository.UpdateAsync(updatePupil);

        public Task DeletePupil(int id) => _repository.RemoveByIdAsync(id);

        public async Task<PupilToView> GetPupil(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<PupilToView>(model);
        }

        public IEnumerable<PupilToView> GetPupilsByClass(int classId) => _repository.GetAll()
                .Where(p => p.ClassId == classId)
                .Select(_mapper.Map<PupilToView>)
                .ToList();
    }
}
