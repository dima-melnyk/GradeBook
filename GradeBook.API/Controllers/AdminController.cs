using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public Task<IEnumerable<UserModel>> GetUsers() => _adminService.GetUsers();

        [HttpPost]
        public Task UpdateRole([FromBody] UpdateRole updateRole) => _adminService.UpdateRole(updateRole);
    }
}
