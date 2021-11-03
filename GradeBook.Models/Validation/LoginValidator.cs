using FluentValidation;
using GradeBook.Models.Auth;

namespace GradeBook.Models.Validation
{
    public class LoginValidator : AbstractValidator<LoginUser>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty().EmailAddress();
            RuleFor(l => l.Password).NotEmpty();
        }
    }
}
