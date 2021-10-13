using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.DTOs;
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

        public async Task CreatePupil(CreatePupilDTO newPupil)
        {
            var model = _mapper.Map<Pupil>(newPupil);
            await _repository.AddAsync(model);
        }

        public async Task UpdatePupil(int id, UpdatePupilDTO updatePupil)
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

        public async Task<PupilDTO> GetPupil(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<PupilDTO>(model);
        }

        public List<PupilDTO> GetPupilsByClass(int classId)
        {
            return _repository.GetAll()
                .Where(p => p.ClassId == classId)
                .Select(_mapper.Map<PupilDTO>)
                .ToList();
        }
    }
}
