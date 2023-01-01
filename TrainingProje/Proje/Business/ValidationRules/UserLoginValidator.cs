using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class UserLoginValidator : AbstractValidator<UserForLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreniz boş geçilemez!");
        }
    }
}
