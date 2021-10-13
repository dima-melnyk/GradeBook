using GradeBook.BusinessLogic.Models;
using GradeBook.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet, Route("{id}")]
        public async Task<ClassToView> GetClass([FromRoute] int id)
        {
            return await _classService.GetClass(id);
        }

        [HttpPost]
        public async Task CreateClass([FromBody] CreateClass createClass)
        {
            await _classService.CreateClass(createClass);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task DeleteClass([FromRoute] int id)
        {
            await _classService.DeleteClass(id);
        }
    }
}
