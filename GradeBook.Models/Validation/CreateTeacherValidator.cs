using FluentValidation;
using GradeBook.Models.Write;

namespace GradeBook.Models.Validation
{
    public class CreateTeacherValidator : AbstractValidator<CreateTeacher>
    {
        public CreateTeacherValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
