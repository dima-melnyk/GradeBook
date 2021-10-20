﻿using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.BusinessLogic.Queries;
using GradeBook.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GradeBook.API.Controllers
{
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
        public IEnumerable<GradeToView> GetGrades([FromQuery] GradeQuery query) => _gradeService.GetGrades(query);

        [HttpGet("{id}")]
        public Task<GradeToView> GetGrade([FromRoute] int id) => _gradeService.GetGrade(id);

        [HttpPost]
        public async Task CreateGrade([FromBody] CreateGrade createGrade)
        {
            var model = _mapper.Map<Grade>(createGrade);
            await _gradeService.CreateGrade(model);
        }

        [HttpPut("{id}")]
        public async Task UpdateGrade([FromRoute] int id, [FromBody] UpdateGrade updateGrade)
        {
            var model = _mapper.Map<Grade>(updateGrade);
            model.Id = id;
            await _gradeService.UpdateGrade(model);
        }

        [HttpDelete("{id}")]
        public Task DeleteGrade([FromRoute] int id) => _gradeService.DeleteGrade(id);
    }
}
