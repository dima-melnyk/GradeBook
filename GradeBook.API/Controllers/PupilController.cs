using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Models;


namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private IPupilService _pupilService;
        public PupilController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        [HttpGet]
        public IEnumerable<PupilToView> GetPupils([FromQuery] int classId)
        {
            return _pupilService.GetPupilsByClass(classId);
        }

        [HttpGet, Route("{id}")]
        public async Task<PupilToView> GetPupil([FromRoute] int id)
        {
            return await _pupilService.GetPupil(id);
        }

        [HttpPost]
        public async Task CreatePupil([FromBody] CreatePupil createPupil)
        {
            await _pupilService.CreatePupil(createPupil);
        }

        [HttpPut, Route("{id}")]
        public async Task UpdatePupil([FromRoute] int id, [FromBody] UpdatePupil updatePupil)
        {
            await _pupilService.UpdatePupil(id, updatePupil);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task DeletePupil([FromRoute] int id)
        {
            await _pupilService.DeletePupil(id);
        }
    }
}
