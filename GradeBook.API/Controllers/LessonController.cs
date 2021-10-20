using AutoMapper;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Models;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
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
        public async Task<LessonToView> GetLesson([FromRoute] int id)
        {
            return await _lessonService.GetLesson(id);
        }

        [HttpGet]
        public List<LessonToView> GetLessons([FromQuery] LessonQuery query)
        {
            return _lessonService.GetLessons(query);
        }

        [HttpPost]
        public async Task CreateLesson([FromBody] CreateLesson createLesson)
        {
            var model = _mapper.Map<Lesson>(createLesson);
            await _lessonService.CreateLesson(model);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteLesson([FromRoute] int id)
        {
            await _lessonService.DeleteLesson(id);
        }
    }
}
