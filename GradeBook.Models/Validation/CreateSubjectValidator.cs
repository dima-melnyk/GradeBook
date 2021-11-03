using FluentValidation;
using GradeBook.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Models.Validation
{
    public class CreateSubjectValidator : AbstractValidator<CreateSubject>
    {
        public CreateSubjectValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
