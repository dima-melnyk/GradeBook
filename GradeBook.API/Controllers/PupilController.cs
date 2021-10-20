using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using AutoMapper;
using GradeBook.DataAccess.Entities;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        private readonly IMapper _mapper;

        public PupilController(IPupilService pupilService, IMapper mapper)
        {
            _pupilService = pupilService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PupilToView> GetPupils([FromQuery] int classId) => _pupilService.GetPupilsByClass(classId);

        [HttpGet("{id}")]
        public Task<PupilToView> GetPupil([FromRoute] int id) => _pupilService.GetPupil(id);

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
        public Task DeletePupil([FromRoute] int id) => _pupilService.DeletePupil(id);
    }
}
