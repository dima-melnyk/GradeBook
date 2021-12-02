using FluentValidation;
using GradeBook.Models.Write;

namespace GradeBook.Models.Validation
{
    public class UpdatePupilValidator : AbstractValidator<UpdatePupil>
    {
        public UpdatePupilValidator()
        {
            RuleFor(u => u.ClassId).NotEmpty();
        }
    }
}
