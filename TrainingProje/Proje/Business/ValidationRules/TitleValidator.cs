using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class TitleValidator : AbstractValidator<Title>
    {
        public TitleValidator()
        {
            RuleFor(x => x.TitleName).NotEmpty().WithMessage("Unvan ismi boş bırakılamaz");
        }
    }
}
