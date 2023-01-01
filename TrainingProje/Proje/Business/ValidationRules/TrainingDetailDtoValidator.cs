using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class TrainingDetailDtoValidator : AbstractValidator<TrainingDetailDto>
    {
        public TrainingDetailDtoValidator()
        {
            RuleFor(x => x.kota).NotEmpty().WithMessage("Kota boş geçilemez!").When(x => x.kota == 0);
            RuleFor(x => x.kota).GreaterThan(0).WithMessage("Kota sıfırdan büyük olmalı!")
                                .LessThan(100).WithMessage("Kota 100 den küçük olmalıdır!");
            RuleFor(x => x.TrainingName).NotEmpty().WithMessage("Eğitim ismi boş geçilemez!");
            RuleFor(x => x.TrainingStartdate.Date).NotEmpty().WithMessage("Eğitimin başlangıç tarihini giriniz!");
            //RuleFor(x => x.Trainingstartdate).LessThanOrEqualTo(x => x.Traininglastdate).WithMessage("Eğitim başlangıç tarihi eğitim bitiş tarihinden küçük ya da eşit olamaz!");
            //RuleFor(x => x.Trainingdate).LessThanOrEqualTo(x => x.Trainingstartdate).WithMessage("Eğitim son başvuru tarihi eğitimin başlangıç tarihinden küçük ya da eşit olamaz!");
            RuleFor(x => x.TrainingLastdate.Date).NotEmpty().WithMessage("Eğitimin bitiş tarihini giriniz!");
            RuleFor(x => x.Trainingdate.Date).NotEmpty().WithMessage("Eğitimin son başvuru tarihini giriniz!");
            RuleFor(x => x.TrainingStartdate).LessThan(x => x.TrainingLastdate).WithMessage("Eğitim başlangıç tarihi eğitim bitiş tarihinden küçük olamaz!");
            RuleFor(x => x.Trainingdate).LessThan(x => x.TrainingStartdate).WithMessage("Eğitim son başvuru tarihi eğitimin başlangıç tarihinden küçük ya da eşit olamaz!");
            RuleFor(x => x.Trainingdate).GreaterThan(DateTime.Now.Date).WithMessage("Eğitimin son başvuru tarihi bugünün tarihinden büyük olmalı!");

            //RuleFor(x => x.Trainingdate).Must(d => d.Trainingdate <= DateTime.Today).WithMessage("Eğitim son başvuru tarihi eğitimin başlangıç tarihinden küçük ya da eşit olamaz!");
            //RuleFor(x => x.TransactionDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Transaction Date cannot be any past date.");
        }


    }
}
