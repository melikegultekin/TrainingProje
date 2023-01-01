using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class EducatorLoginValidator : AbstractValidator<EducatorForLoginDto>
    {
        public EducatorLoginValidator()
        {
            RuleFor(x => x.EUserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreniz boş geçilemez!");
        }
    }
}
