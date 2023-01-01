using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class EducatorRegisterValidator : AbstractValidator<EducatorForRegisterDto>
    {
        public EducatorRegisterValidator()
        {
            RuleFor(x => x.EUserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.EducatorFullName).NotEmpty().WithMessage("Adınız Soyadınız boş geçilemez!");
            RuleFor(x => x.Tc).NotEmpty().WithMessage("Tc kimlik boş geçilemez!");
            //RuleFor(x=>x.Tc).Length(11,11).WithMessage("Kimlik numaranız 11 haneli olmak zorunda!").When(x=>x.IsTurkish);
            //RuleFor(s => s.Tc).NotEmpty().Length(11).WithMessage("Kimlik Numaranız 11 haneli olmaz zorunda").When(s => s.IsTurkish);
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreniz boş geçilemez!");
            RuleFor(x => x.Passwordtekrar).NotEmpty().WithMessage("Şifre tekrarı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresiniz boş geçilemez!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz!").When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Password).Equal(x => x.Passwordtekrar).WithMessage("Şifreler aynı değil tekrar deneyiniz!");
        }
    }
}
