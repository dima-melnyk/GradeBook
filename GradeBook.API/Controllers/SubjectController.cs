using AutoMapper;
using GradeBook.Models.Write;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using GradeBook.Models.Read;
using System.Collections.Generic;

namespace GradeBook.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet("subjects")]
        public IEnumerable<SubjectModel> GetSubjects() => _subjectService.GetSubjects();

        [HttpPost]
        public async Task CreateSubject([FromBody] CreateSubject createSubject)
        {
            var model = _mapper.Map<Subject>(createSubject);
            await _subjectService.CreateSubject(model);
        }
    }
}
