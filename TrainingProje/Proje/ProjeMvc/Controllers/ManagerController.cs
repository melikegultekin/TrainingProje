using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjeMvc.Models;

namespace ProjeMvc.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public IActionResult Index()
        {
            return View();
        }

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public IActionResult LoginM()
        {
            return View();
        }
        [HttpPost("loginM")]
        public IActionResult LoginM(ManagerForLoginDto managerForLoginDto)
        {
            ManagerLoginValidator managerloginValidator = new ManagerLoginValidator();
            ValidationResult results = managerloginValidator.Validate(managerForLoginDto);
            if (results.IsValid)
            {
                _managerService.LoginM(managerForLoginDto);
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

            Manager managerToCheck = projeContext.Managers.Where(x => x.ManagerName == managerForLoginDto.ManagerName).FirstOrDefault();

            if (managerToCheck == null)
            {
                TempData["AlertMessage"] = "Hatalı kullanıcı...!";
                //return RedirectToAction(actionName: "Hata", controllerName: "User");
                return View();
            }


            HttpContext.Session.SetString("ManagerName", managerForLoginDto.ManagerName);
            TempData["AlertMessage"] = "Giriş işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Manager");

        }

        

        public ActionResult GetAll()
        {
            ViewBag.username = HttpContext.Session.GetString("ManagerName");
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Include(x => x.Educator).ToList();
            List<TrainingProgramDetail> trainingProgramDetails2 = projeContext.TrainingProgramDetail.Include(x => x.Lesson).ToList();
            List<TrainingProgram> trainingProgram = projeContext.TrainingPrograms.Include(x => x.Training).ToList();
            Educator educator1 = projeContext.Educators.Where(x => x.EUserName == HttpContext.Session.GetString("EUserName")).FirstOrDefault();
            //ViewBag.EducatorId = educator1.EducatorId;
            List<Lesson> lessons = projeContext.Lessons.ToList();
            Educator educator = projeContext.Educators.Where(x => x.EUserName == HttpContext.Session.GetString("EUserName")).FirstOrDefault();
            List<TrainingProgramDetail> trainingProgramDetails1 = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == educator.EducatorId).ToList();
            List<Class> sınıflar = projeContext.Classes.ToList();
            List<Class> sınıflar1 = new List<Class>();
            List<Class> sınıflar2 = new List<Class>();
            if (trainingProgramDetails1 != null)
            {
                foreach (var s in sınıflar)
                {
                    foreach (var t in trainingProgramDetails1)
                    {
                        if (t.TrainingProgramId == s.TrainingProgramId)
                        {
                            if (sınıflar1.Count == 0)
                            {
                                sınıflar1.Add(s);
                            }

                            for (int sınıf = 0; sınıf < sınıflar1.Count; sınıf++)
                            {
                                if (sınıflar1[sınıf].ClassName == s.ClassName)
                                {
                                    break;
                                }
                                sınıflar1.Add(s);
                            }
                            
                        }

                    }
                }
                
            }
            else
            {
                sınıflar1 = sınıflar;
            }
            sınıflar1 = sınıflar1.Distinct().ToList();
            return View(sınıflar1);
        }

        public ActionResult GetAllT()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Lesson> lessons = projeContext.Lessons.Include(x => x.Training).ToList();
            
            List<Training> trainings = projeContext.Trainings.ToList();
            return View(trainings);
        }

        [HttpGet]
        public ActionResult Educator()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Educator> educators = projeContext.Educators.Include(x => x.Title).ToList();
            List<Title> titles = projeContext.Titles.ToList();

            return View(educators);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            ViewBag.username = HttpContext.Session.GetString("Managername");
            HttpContext.Session.Remove("Managername");
            TempData["AlertMessage"] = "Çıkış Yaptınız...!"; 
            return Redirect("https://localhost:5001/");
        }

        [HttpGet]
        public ActionResult EProgram(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            Educator educator = projeContext.Educators.Where(x => x.EducatorId == EducatorId).FirstOrDefault();
            Educator educator1 = projeContext.Educators.Where(x => x.EducatorId == EducatorId).FirstOrDefault();
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == educator.EducatorId).FirstOrDefault();

            if (trainingProgramDetail != null)
            {
                TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == trainingProgramDetail.TrainingProgramId).FirstOrDefault();
                List<SelectListItem> training = (from i in projeContext.Lessons.Where(x => x.TrainingId == trainingProgram.TrainingId).ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.LessonName,
                                                     Value = i.LessonId.ToString()
                                                 }).ToList();
                ViewBag.Lessons = training;
            }

            List<SelectListItem> title1 = (from i in projeContext.Titles.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TitleName,
                                               Value = i.TitleId.ToString()
                                           }).ToList();
            ViewBag.Titles = title1;

            Title title = projeContext.Titles.Where(x => x.TitleId == educator.TitleId).FirstOrDefault();
            ViewBag.EducatorId = educator.EducatorId;
            ViewBag.TitleName = title.TitleName;
            ViewBag.TitleId = educator.TitleId;
            ViewBag.EducatorFullName = educator.EducatorFullName;
            ViewBag.Tc = educator.Tc;
            ViewBag.EUserName = educator.EUserName;
            ViewBag.Email = educator.Email;

            List<Lesson> lesson1 = projeContext.Lessons.Include(x => x.Training).ToList();

            //List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Where(x => x.ClassId == ClassId).ToList();
            List<SelectListItem> sınıf = (from i in projeContext.Classes.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.ClassName,
                                              Value = i.ClassId.ToString()
                                          }).ToList();
            ViewBag.Classes = sınıf;
            Lesson lesson = projeContext.Lessons.Where(x => x.TrainingId != null).FirstOrDefault();

            return View(trainingProgramDetail);
        }


        public JsonResult GetTrainingProgramsByEducator(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgramDetailViewModel> listmodel = new List<TrainingProgramDetailViewModel>();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == EducatorId).ToList();
            foreach (var item in trainingProgramDetails)
            {
                Class sınıf = projeContext.Classes.Where(x => x.TrainingProgramId == item.TrainingProgramId).FirstOrDefault();
                listmodel.Add(new TrainingProgramDetailViewModel()
                {
                    StartDate = item.StartDate,
                    ClassId = sınıf.ClassId,
                    Description = item.Description,
                    EducatorId = item.EducatorId,
                    EndDate = item.EndDate,
                    LessonId = item.LessonId,
                    TrainingProgramDetailId = item.TrainingProgramDetailId,
                    TrainingProgramId = item.TrainingProgramId
                });
            }

            return Json(listmodel);
        }

    }
}
