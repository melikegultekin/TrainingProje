using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class EducatorValidator : AbstractValidator<Educator>
    {
        public EducatorValidator()
        {
            RuleFor(x => x.EducatorFullName).NotEmpty().WithMessage("Eğitimci Adı Soyadı boş geçilemez!");
            RuleFor(x => x.EUserName).NotEmpty().WithMessage("Eğitimci Kullanıcı adı boş geçilemez!");
        }
    }
}
