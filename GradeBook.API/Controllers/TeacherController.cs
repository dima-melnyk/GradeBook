using AutoMapper;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherManager _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherManager teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public Task<TeacherToView> GetTeacher([FromRoute] int id) => _teacherService.GetTeacher(id);

        [HttpPost]
        public async Task CreateTeacher([FromBody] CreateTeacher createTeacher)
        {
            var model = _mapper.Map<Teacher>(createTeacher);
            await _teacherService.CreateTeacher(model);
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteTeacher(int id) => _teacherService.DeleteTeacher(id);
    }
}
