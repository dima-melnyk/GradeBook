using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models.Auth
{
    public class LoginUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, enter password")]
        public string Password { get; set; }
    }
}
