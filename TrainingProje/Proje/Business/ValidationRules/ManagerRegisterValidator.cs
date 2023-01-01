using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class ManagerRegisterValidator : AbstractValidator<ManagerForRegisterDto>
    {
        public ManagerRegisterValidator()
        {

            RuleFor(x => x.ManagerName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adınız boş geçilemez!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadınız boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreniz boş geçilemez!");
            RuleFor(x => x.Passwordtekrar).NotEmpty().WithMessage("Şifre tekrarı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresiniz boş geçilemez!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz!").When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Password).Equal(x => x.Passwordtekrar).WithMessage("Şifreler aynı değil tekrar deneyiniz!");
        }
    }
}
