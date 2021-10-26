using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(UserManager<IdentityUser<int>> userManager, 
            RoleManager<IdentityRole<int>> roleManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task Register(RegisterUser user)
        {
            var newUser = _mapper.Map<IdentityUser<int>>(user);
            newUser.PhoneNumberConfirmed = true;
            newUser.EmailConfirmed = true;

            if (await _userManager.FindByEmailAsync(newUser.Email) != null)
                throw new ArgumentException("User is already created");

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
                throw new ArgumentException(string.Join('\n', result.Errors.Select(e => e.Description).ToArray()));

            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            await _userManager.AddToRoleAsync(identityUser, "User");
        }

        public async Task<string> Login(LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, loginUser.Password)))
                throw new ArgumentException("Your email or password is incorrect");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _userManager.GetRolesAsync(user).Result.FirstOrDefault())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            var result = new { token = new JwtSecurityTokenHandler().WriteToken(token), username = user.UserName };

            return JsonSerializer.Serialize(result);
        }
    }
}
