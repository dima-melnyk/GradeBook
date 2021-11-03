using FluentValidation;
using GradeBook.Models.Write;

namespace GradeBook.Models.Validation
{
    public class CreateClassValidator : AbstractValidator<CreateClass>
    {
        public CreateClassValidator() => RuleFor(r => r.Name).NotEmpty();
    }
}
