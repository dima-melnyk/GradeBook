using GradeBook.Models.Read;
using GradeBook.Models.Write;
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
        public Task<ClassToView> GetClass([FromRoute] int id) => _classService.GetClass(id);

        [HttpPost]
        public async Task CreateClass([FromBody] CreateClass createClass)
        {
            var model = _mapper.Map<Class>(createClass);
            await _classService.CreateClass(model);
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteClass([FromRoute] int id) => _classService.DeleteClass(id);
    }
}
