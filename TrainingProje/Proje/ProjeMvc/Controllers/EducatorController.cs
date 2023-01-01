using Business.Abstract;
using Business.ValidationRules;
using Core.Utilities.Security.Hashing;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeMvc.Models;

namespace ProjeMvc.Controllers
{
    public class EducatorController : Controller
    {
        private readonly IEducatorService _educatorService;

        public EducatorController(IEducatorService educatorService)
        {
            _educatorService = educatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginE()
        {
            return View();
        }

        [HttpPost("loginE")]
        public IActionResult LoginE(EducatorForLoginDto educatorForLoginDto)
        {
            EducatorLoginValidator educatorloginValidator = new EducatorLoginValidator();
            ValidationResult results = educatorloginValidator.Validate(educatorForLoginDto);
            if (results.IsValid)
            {
                _educatorService.LoginE(educatorForLoginDto);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            Proje2Context projeContext = new Proje2Context();

            Educator educatorToCheck = projeContext.Educators.Where(x => x.EUserName == educatorForLoginDto.EUserName).FirstOrDefault();

            if (educatorToCheck == null)
            {
                TempData["ErrorMessage"] = "Hatalı kullanıcı...!";
                //return RedirectToAction(actionName: "Hata", controllerName: "User");
                return View();
            }
            if (!HashingHelper.VerifyPasswordHash(educatorForLoginDto.Password, educatorToCheck.PasswordHash, educatorToCheck.PasswordSalt))
            {
                TempData["ErrorMessage"] = "Hatalı şifre...!";
                //return RedirectToAction(actionName: "UserVar", controllerName: "User");
                return View();
            }

            HttpContext.Session.SetString("EUserName", educatorForLoginDto.EUserName);
            Educator educator = projeContext.Educators.Where(x => x.EUserName == HttpContext.Session.GetString("EUserName")).FirstOrDefault();
            ViewBag.EducatorFullName = educator.EducatorFullName;
            TempData["AlertMessage"] = "Eğitimci Giriş işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Manager");


        }

        [HttpGet]
        public IActionResult RegisterEd()
        {
            Proje2Context projeContext = new Proje2Context();
            List<SelectListItem> isimler = (from i in projeContext.Titles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TitleName,
                                                Value = i.TitleId.ToString()
                                            }).ToList();
            ViewBag.Unvan = isimler;
            return View();
        }

        [HttpPost]
        public IActionResult RegisterEd(EducatorForRegisterDto educatorForRegisterDto)
        {
            educatorForRegisterDto.EducatorId = 0;
            Proje2Context projeContext = new Proje2Context();
            bool educatorExists = !(projeContext.Educators.Where(x => x.EUserName == educatorForRegisterDto.EUserName).FirstOrDefault() == null);
            if (educatorExists)
            {

                return Json("Girdiğiniz kullanıcı mevcut lütfen başka kullanıcı ismi giriniz!...");
                
            }
            List<SelectListItem> isimler = (from i in projeContext.Titles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TitleName,
                                                //Value = i.UserName.ToString()
                                                Value = i.TitleId.ToString()
                                            }).ToList();
            ViewBag.Liste = isimler;
            EducatorRegisterValidator educatorregisterValidator = new EducatorRegisterValidator();
            ValidationResult results = educatorregisterValidator.Validate(educatorForRegisterDto);
            if (results.IsValid)
            {
                _educatorService.RegisterE(educatorForRegisterDto, educatorForRegisterDto.Password, educatorForRegisterDto.Passwordtekrar);
            }
            else
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;
                    return Json(message);
                }
                //return Json(message);
            }
            HttpContext.Session.SetString("EUserName", educatorForRegisterDto.EUserName);

            HashingHelper.CreatePasswordHash(educatorForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            projeContext.Educators.Add(new Educator() { EUserName = educatorForRegisterDto.EUserName, EducatorFullName = educatorForRegisterDto.EducatorFullName, Tc = educatorForRegisterDto.Tc, Email = educatorForRegisterDto.Email, PasswordHash = passwordHash, PasswordSalt = passwordSalt, TitleId = educatorForRegisterDto.TitleId });
            //TempData["AlertMessage"] = "Eğitimci kayıt işleminiz başarılı...!";
            return Json("200");
            //return RedirectToAction(actionName: "Educator", controllerName: "Admin");

        }

        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Educator> educators = projeContext.Educators.Include(x => x.Title).ToList();
            List<Title> titles = projeContext.Titles.ToList();

            return View(educators);
        }



        public ActionResult Detailss(int EducatorId)
        {
            var result = _educatorService.GetById(EducatorId);
            return View(result);
        }

        [HttpGet]
        public ActionResult Update(int EducatorId)
        {
            var result = _educatorService.GetById(EducatorId);
            Proje2Context projeContext = new Proje2Context();
            Title title = projeContext.Titles.Where(x => x.TitleId == result.TitleId).FirstOrDefault();

            List<SelectListItem> egitmen = (from i in projeContext.Titles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TitleName,
                                                Value = i.TitleId.ToString()
                                            }).ToList();
            ViewBag.Unvan = egitmen;
            ViewBag.TitleName = title.TitleName;
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Educator model)
        {

            Proje2Context projeContext = new Proje2Context();
            EducatorValidator educatorValidator = new EducatorValidator();
            ValidationResult results = educatorValidator.Validate(model);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            List<SelectListItem> egitmen = (from i in projeContext.Titles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.TitleName,
                                                Value = i.TitleId.ToString()
                                            }).ToList();
            ViewBag.Unvan = egitmen;
            ///Training training = projeContext.Trainings.Where(x => x.TrainingId == waiting.TrainingId).FirstOrDefault();
            model.EUserName = HttpContext.Session.GetString("EserName");
            Title title = projeContext.Titles.Where(x => x.TitleId == model.TitleId).FirstOrDefault();
            var result = _educatorService.GetById(model.EducatorId);
            model.TitleId = title.TitleId;
            ViewBag.TitleName = title.TitleName;
            model.EUserName = result.EUserName;
            model.PasswordSalt = result.PasswordSalt;
            model.PasswordHash = result.PasswordHash;
            ViewBag.EducatorId = model.EducatorId;
            ViewBag.TitleName = title.TitleName;
            ViewBag.TitleId = model.TitleId;
            ViewBag.EducatorFullName = model.EducatorFullName;
            ViewBag.Tc = model.Tc;
            ViewBag.EUserName = model.EUserName;
            ViewBag.Email = model.Email;
            _educatorService.Update(model);
            return Json("200");
        }


        [HttpGet]
        public ActionResult Delete(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == EducatorId).ToList();
            foreach (var t in trainingProgramDetails)
            {
                if (t != null)
                {
                    if (t.StartDate > DateTime.Now)
                    {
                        return Json("5");
                    }
                }
            }
           
            
            _educatorService.Delete(EducatorId);
            return Json("200");
        }



        public ActionResult AllProgram()
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == x.EducatorId).ToList();
            return View();
        }


        public JsonResult GetTrainingProgramsByEducator(GetByEducator model)
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgramDetailViewModel> listmodel = new List<TrainingProgramDetailViewModel>();
            Educator educator = projeContext.Educators.Where(x => x.EUserName == HttpContext.Session.GetString("EUserName")).FirstOrDefault();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == model.EducatorId).ToList();

            foreach (var item in trainingProgramDetails)
            {
                if(trainingProgramDetails == null)
                {
                    return Json("9");
                }
                Class sınıf = projeContext.Classes.Where(x => x.TrainingProgramId == item.TrainingProgramId).FirstOrDefault();
                listmodel.Add(new TrainingProgramDetailViewModel()
                {
                    StartDate=item.StartDate,
                    ClassId=sınıf.ClassId,
                    Description=item.Description,
                    EducatorId=item.EducatorId,
                    EndDate=item.EndDate,
                    LessonId=item.LessonId,
                    TrainingProgramDetailId=item.TrainingProgramDetailId,
                    TrainingProgramId=item.TrainingProgramId
                });
            }

            return Json(listmodel);
        }

        [HttpGet]
        public IActionResult Educator(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            Educator educator = projeContext.Educators.Where(x => x.EUserName == HttpContext.Session.GetString("EUserName")).FirstOrDefault();
            TrainingProgramDetail trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == educator.EducatorId).FirstOrDefault();
            TrainingProgramDetail trainingProgramDetail1 = new TrainingProgramDetail();
            if (trainingProgramDetails == null)
            {
                return View(trainingProgramDetail1);
                //TempData["AlertMessage"] = "Programınız mevcut değil...!";
                //return RedirectToAction(actionName: "GetAll", controllerName: "Manager");
            }
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == trainingProgramDetails.TrainingProgramId).FirstOrDefault();
            Educator educator1 = projeContext.Educators.Where(x => x.EducatorId == educator.EducatorId).FirstOrDefault();
            List<Educator> educators = projeContext.Educators.Include(x => x.Title).ToList();
            //Title title = projeContext.Titles.Where(x => x.TitleId == educator.TitleId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.TrainingProgramId == trainingProgramDetails.TrainingProgramId).FirstOrDefault();
            //ViewBag.ClassId = sınıf.ClassId;
            //ViewBag.ClassName = sınıf.ClassName;
            Title title = projeContext.Titles.Where(x => x.TitleId == educator.TitleId).FirstOrDefault();
            ViewBag.EducatorId = educator.EducatorId;
            ViewBag.TitleName = title.TitleName;
            ViewBag.EducatorFullName = educator.EducatorFullName;
            ViewBag.ClassName = sınıf.ClassName;
            //List<SelectListItem> training = (from i in projeContext.Lessons.Where(x => x.LessonId == trainingProgramDetails.LessonId).ToList()
            List<SelectListItem> training = (from i in projeContext.Lessons.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.LessonName,
                                                 Value = i.LessonId.ToString()
                                             }).ToList();
            ViewBag.Trainings = training;



            List<SelectListItem> sınıflar = (from i in projeContext.Classes.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ClassName,
                                                 Value = i.ClassId.ToString()
                                             }).ToList();
            ViewBag.Sınıflar = sınıflar;

            return View(trainingProgramDetails);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            ViewBag.username = HttpContext.Session.GetString("EUsername");
            HttpContext.Session.Remove("EUsername");
            //return View();
            TempData["AlertMessage"] = "Eğitimci Çıkış Yaptınız...!";
            //return RedirectToAction(actionName: "Login", controllerName: "User");
            return Redirect("https://localhost:5001/");
        }
    }
}
