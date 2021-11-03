using FluentValidation;
using GradeBook.Models.Auth;

namespace GradeBook.Models.Validation
{
    public class RegisterValidator : AbstractValidator<RegisterUser>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Username).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.Birthday).NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
        }
    }
}
