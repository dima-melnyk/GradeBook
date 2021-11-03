using System;
using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models.Auth
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
    }
}
