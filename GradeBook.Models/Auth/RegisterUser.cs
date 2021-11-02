using System;
using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models.Auth
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Please, enter password")]
        public string Password { get; set; }
    }
}
