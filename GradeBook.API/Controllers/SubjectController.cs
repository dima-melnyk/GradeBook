using AutoMapper;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
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

        [HttpPost]
        public async Task CreateSubject([FromBody] CreateSubject createSubject)
        {
            var model = _mapper.Map<Subject>(createSubject);
            await _subjectService.CreateSubject(model);
        }
    }
}
