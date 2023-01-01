using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class TrainingProgramOlusturValidator : AbstractValidator<TrainingProgram>
    {
        public TrainingProgramOlusturValidator()
        {
            //RuleFor(x => x.TrainingId).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            //RuleFor(x => x.Kota).NotEmpty().WithMessage("Şifreniz boş geçilemez!");
            //RuleFor(x => x.Kota).GreaterThan(x => x.Training.kota).WithMessage("Girilen tarih eğitim başlangıç tarihinden büyük olamaz!");
        }
    }
}





