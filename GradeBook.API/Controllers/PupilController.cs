using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using AutoMapper;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GradeBook.API.Controllers
{
    [Authorize(Roles = "Teacher, Admin")]
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
        public Task<IEnumerable<PupilModel>> GetPupils([FromQuery] int classId) => _pupilService.GetPupilsByClass(classId);

        [HttpGet("{id}")]
        public Task<PupilModel> GetPupil([FromRoute] int id) => _pupilService.GetPupil(id);

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task UpdatePupil([FromRoute] int id, [FromBody] UpdatePupil updatePupil)
        {
            var updateModel = _mapper.Map<UserClass>(updatePupil);
            updateModel.Id = id;
            await _pupilService.UpdatePupil(updateModel);
        }
    }
}
