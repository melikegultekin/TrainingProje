using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator() 
        {
            RuleFor(x => x.LessonName).NotEmpty().WithMessage("Ders ismi boş geçilemez!");
        }
    }
}
