using AutoMapper;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Models;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService _teacherService;
        private IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<TeacherToView> GetTeacher([FromRoute] int id)
        {
            return await _teacherService.GetTeacher(id);
        }

        [HttpPost]
        public async Task CreateTeacher([FromBody] CreateTeacher createTeacher)
        {
            var model = _mapper.Map<Teacher>(createTeacher);
            await _teacherService.CreateTeacher(model);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteTeacher(int id)
        {
            await _teacherService.DeleteTeacher(id);
        }
    }
}
