using FluentValidation;
using GradeBook.Models.Write;

namespace GradeBook.Models.Validation
{
    public class CreateLessonValidator : AbstractValidator<CreateLesson>
    {
        public CreateLessonValidator()
        {
            RuleFor(c => c.ClassId).NotEmpty();
            RuleFor(c => c.SubjectId).NotEmpty();
            RuleFor(c => c.TeacherId).NotEmpty();
        }
    }
}
