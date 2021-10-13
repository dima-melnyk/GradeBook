using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Models;
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
        private IEntityRepository<Pupil> _repository;
        private IMapper _mapper;

        public PupilService(IEntityRepository<Pupil> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreatePupil(CreatePupil newPupil)
        {
            var model = _mapper.Map<Pupil>(newPupil);
            await _repository.AddAsync(model);
        }

        public async Task UpdatePupil(int id, UpdatePupil updatePupil)
        {
            var model = await _repository.GetByIdAsync(id);
            var updateModel = _mapper.Map<Pupil>(updatePupil);
            updateModel.Id = model.Id;
            await _repository.UpdateAsync(updateModel);
        }

        public async Task DeletePupil(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(model);
        }

        public async Task<PupilToView> GetPupil(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<PupilToView>(model);
        }

        public List<PupilToView> GetPupilsByClass(int classId)
        {
            return _repository.GetAll()
                .Where(p => p.ClassId == classId)
                .Select(_mapper.Map<PupilToView>)
                .ToList();
        }
    }
}
