using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Repository.Interfaces;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using GradeBook.DataAccess.Entities.Base;

namespace GradeBook.BusinessLogic.Services
{
    public class PupilService : IPupilService
    {
        private readonly IEntityRepository<Pupil> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<UserBase> _userManager;

        public PupilService(IEntityRepository<Pupil> repository, IMapper mapper, UserManager<UserBase> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreatePupil(Pupil newPupil, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            newPupil.Id = user.Id;
            await _userManager.AddToRoleAsync(user, "Pupil");
            await _repository.AddAsync(newPupil);
        }

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
