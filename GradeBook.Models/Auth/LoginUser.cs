using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models.Auth
{
    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
