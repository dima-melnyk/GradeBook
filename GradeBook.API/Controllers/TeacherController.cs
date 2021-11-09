using AutoMapper;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GradeBook.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherManager _teacherService;

        public TeacherController(ITeacherManager teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("{id}")]
        public Task<TeacherModel> GetTeacher([FromRoute] int id) => _teacherService.GetTeacher(id);

        [HttpDelete("delete/{id}")]
        public Task DeleteTeacher(int id) => _teacherService.DeleteTeacher(id);
    }
}
