using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class ManagerLoginValidator : AbstractValidator<ManagerForLoginDto>
    {
        public ManagerLoginValidator()
        {
            RuleFor(x => x.ManagerName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreniz boş geçilemez!");
        }
    }
}
