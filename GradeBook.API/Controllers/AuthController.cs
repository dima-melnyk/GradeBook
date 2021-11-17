using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GradeBook.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public Task Register([FromBody] RegisterUser user) => _authService.Register(user);

        [HttpPost("login")]
        public Task<string> Login([FromBody] LoginUser user) => _authService.Login(user);
    }
}
