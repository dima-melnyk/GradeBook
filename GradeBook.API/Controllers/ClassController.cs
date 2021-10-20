using GradeBook.BusinessLogic.Models;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GradeBook.DataAccess.Entities;
using AutoMapper;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;

        public ClassController(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ClassToView> GetClass([FromRoute] int id)
        {
            return await _classService.GetClass(id);
        }

        [HttpPost]
        public async Task CreateClass([FromBody] CreateClass createClass)
        {
            var model = _mapper.Map<Class>(createClass);
            await _classService.CreateClass(model);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteClass([FromRoute] int id)
        {
            await _classService.DeleteClass(id);
        }
    }
}
