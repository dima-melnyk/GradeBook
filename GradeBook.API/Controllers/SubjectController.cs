using AutoMapper;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private ISubjectService _subjectService;
        private IMapper _mapper;

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
