using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Models;
using AutoMapper;
using GradeBook.DataAccess.Entities;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private IPupilService _pupilService;
        private IMapper _mapper;

        public PupilController(IPupilService pupilService, IMapper mapper)
        {
            _pupilService = pupilService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PupilToView> GetPupils([FromQuery] int classId)
        {
            return _pupilService.GetPupilsByClass(classId);
        }

        [HttpGet("{id}")]
        public async Task<PupilToView> GetPupil([FromRoute] int id)
        {
            return await _pupilService.GetPupil(id);
        }

        [HttpPost]
        public async Task CreatePupil([FromBody] CreatePupil createPupil)
        {
            var model = _mapper.Map<Pupil>(createPupil);
            await _pupilService.CreatePupil(model);
        }

        [HttpPut("{id}")]
        public async Task UpdatePupil([FromRoute] int id, [FromBody] UpdatePupil updatePupil)
        {
            var updateModel = _mapper.Map<Pupil>(updatePupil);
            updateModel.Id = id;
            await _pupilService.UpdatePupil(updateModel);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeletePupil([FromRoute] int id)
        {
            await _pupilService.DeletePupil(id);
        }
    }
}
