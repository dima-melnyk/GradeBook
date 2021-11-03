using AutoMapper;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;

namespace GradeBook.API.Controllers
{
    [Authorize(Roles = "Teacher, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public Task<LessonModel> GetLesson([FromRoute] int id) => _lessonService.GetLesson(id);

        [HttpGet]
        public IEnumerable<LessonModel> GetLessons([FromQuery] LessonQuery query)
        {
            if (User.IsInRole(Role.Teacher.ToString()))
                query.TeacherId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return _lessonService.GetLessons(query);
        }

        [HttpPost]
        public async Task CreateLesson([FromBody] CreateLesson createLesson)
        {
            var model = _mapper.Map<Lesson>(createLesson);
            await _lessonService.CreateLesson(model);
        }

        [HttpDelete("delete/{id}")]
        public Task DeleteLesson([FromRoute] int id) => _lessonService.DeleteLesson(id);
    }
}
