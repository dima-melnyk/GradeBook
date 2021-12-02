using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GradeBook.API.Controllers
{
    [Authorize(Roles = "Pupil, Teacher, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public GradeController(IGradeService gradeService, IMapper mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public Task<IEnumerable<GradeModel>> GetGrades([FromQuery] GradeQuery query)
        {
            if (User.IsInRole(Role.Pupil.ToString()))
                query.PupilId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return _gradeService.GetGrades(query);
        }

        [HttpGet("{id}")]
        public Task<GradeModel> GetGrade([FromRoute] int id) => _gradeService.GetGrade(id, User.Claims);

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task CreateGrade([FromBody] CreateGrade createGrade)
        {
            var model = _mapper.Map<Grade>(createGrade);
            await _gradeService.CreateGrade(model);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("{id}")]
        public async Task UpdateGrade([FromRoute] int id, [FromBody] UpdateGrade updateGrade)
        {
            var model = _mapper.Map<Grade>(updateGrade);
            model.Id = id;
            await _gradeService.UpdateGrade(model);
        }

        [Authorize(Roles = "Teacher")]
        [HttpDelete("{id}")]
        public Task DeleteGrade([FromRoute] int id) => _gradeService.DeleteGrade(id);
    }
}
