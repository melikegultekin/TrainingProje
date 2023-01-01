using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class TrainingProgramDetailValidator : AbstractValidator<TrainingProgramDetail>
    {
        //public TrainingProgramDetailValidator()
        //{
        //    RuleFor(x => x.TrainingName).NotEmpty().WithMessage("Unvan ismi boş bırakılamaz");
        //    //RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş bırakılamaz");
        //    RuleFor(x => x.StartDate).NotEmpty().WithMessage("Eğitim başlama saati boş bırakılamaz");
        //    RuleFor(x => x.EndDate).NotEmpty().WithMessage("Eğitim bitiş saati boş bırakılamaz.");
        //    //RuleFor(x => x.EducatorFullName).NotEmpty().WithMessage("Eğitmen ismi boş bırakılamaz");
        //    //RuleFor(x => x.TrainingName).NotEmpty().WithMessage("Eğitim ismi boş bırakılamaz");

        //    RuleFor(x => x.StartDate).GreaterThan(x => x.Trainingstartdate).WithMessage("Girilen tarih eğitim başlangıç tarihinden büyük olamaz!");
        //    RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("Girilen tarih başlangıç tarihinden büyük olamaz!");
        //    RuleFor(x => x.StartDate).LessThan(x => x.Traininglastdate).WithMessage("Girilen tarih eğitimin bitiş tarihinden küçük olamaz!");
        //    RuleFor(x => x.EndDate).LessThan(x => x.Traininglastdate).WithMessage("Girilen tarih eğitimin bitiş tarihinden küçük olamaz");
        //    //RuleFor(x => x.Trainingdate).LessThan(x => x.Trainingstartdate).WithMessage("Eğitim son başvuru tarihi eğitimin başlangıç tarihinden küçük ya da eşit olamaz!");
        //    RuleFor(x => x.StartDate).GreaterThan(DateTime.Now.Date).WithMessage("Girilen tarih bugünün tarihinden küçük olmalı!");
        //}
    }
}
