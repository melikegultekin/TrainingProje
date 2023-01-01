using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class ClassValidator : AbstractValidator<Class>
    {
        public ClassValidator()
        {
            RuleFor(x => x.ClassName).NotEmpty().WithMessage("Sınıf ismi boş geçilemez!");
            RuleFor(x => x.Kota).NotEmpty().WithMessage("Kota boş geçilemez!");
        }
    }
}
