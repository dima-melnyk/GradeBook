using FluentValidation;
using GradeBook.Models.Write;

namespace GradeBook.Models.Validation
{
    public class CreatePupilValidator : AbstractValidator<CreatePupil>
    {
        public CreatePupilValidator()
        {
            RuleFor(c => c.ClassId).NotEmpty();
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
