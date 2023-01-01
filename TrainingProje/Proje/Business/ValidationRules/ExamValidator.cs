using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(x => x.ExamNot).NotEmpty().WithMessage("Sınav notu boş geçilemez!");
        }
    }
}
