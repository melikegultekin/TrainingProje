using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        private readonly ITrainingProgramDetailService _trainingProgramDetailService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Class> classes = projeContext.Classes.ToList();
            return View(classes);
        }


        [HttpGet]
        public ActionResult Add(int TrainingProgramId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class vs = new Class();
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == TrainingProgramId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.TrainingProgramId == TrainingProgramId).FirstOrDefault();
            if (sınıf.ClassName != null)
            {
                TempData["AlertMessage"] = "Seçilen program mevcut bir sınıfa sahip...!";
                return RedirectToAction(actionName: "GetAll", controllerName: "TrainingProgram");
            }
            vs.TrainingProgramId = trainingProgram.TrainingProgramId;
            return View(vs);
        }

        [HttpPost]
        public ActionResult Add(Class model)
        {
            //model.ClassId = 0;
            Proje2Context projeContext = new Proje2Context();
            Training training = new Training();
            TrainingProgram trainingProgram = new TrainingProgram();
            Class sınıf = projeContext.Classes.Where(x => x.TrainingProgramId == model.TrainingProgramId).FirstOrDefault();

            if (sınıf.ClassName != null)
            {
                return Json("1");
            }
            List<Class> sınıflar = projeContext.Classes.Where(x => x.ClassName == model.ClassName).ToList();
            if (sınıflar.Count == 2)
            {
                return Json("9");
            }
            if (model.ClassName == null && model.Kota != 0)
            {
                return Json("2");
            }
            TrainingProgram trainingProgram2 = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == model.TrainingProgramId).FirstOrDefault();
            Training training1 = projeContext.Trainings.Where(x => x.TrainingId == trainingProgram2.TrainingId).FirstOrDefault();
            if (model.Kota > training1.kota)
            {
                return Json("3");
            }

            TrainingProgram trainingProgram1 = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == model.TrainingProgramId).FirstOrDefault();
            sınıf.TrainingId = trainingProgram1.TrainingId;
            sınıf.TrainingProgramId = trainingProgram1.TrainingProgramId;
            sınıf.ClassName = model.ClassName;
            sınıf.Kota = model.Kota;
            _classService.Update(sınıf);

            training1.kota = training1.kota - model.Kota;
            projeContext.Update(training1);
            int sonuc2 = projeContext.SaveChanges();

            
            return Json("200");
        }


        [HttpGet]
        public ActionResult Update(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            var result = _classService.GetById(ClassId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Class model)
        {
            Proje2Context projeContext = new Proje2Context();


            ClassValidator classValidator = new ClassValidator();
            ValidationResult results = classValidator.Validate(model);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            _classService.Update(model);
            return RedirectToAction(actionName: "GetAll", controllerName: "Class");
        }

        [HttpGet]
        public ActionResult Delete(int ClassId)
        {
            var result = _classService.GetById(ClassId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(Class model)
        {

            Proje2Context projeContext = new Proje2Context();

            Class classes = projeContext.Classes.Where(x => x.ClassId == model.ClassId).FirstOrDefault();
            
            _classService.Delete(classes.ClassId);
            TempData["AlertMessage"] = "Silme işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Class");
        }



        [HttpGet]
        public ActionResult SfListesi(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();

            List<User> users = projeContext.Users.Where(x => x.ClassId == ClassId).ToList();
            
            return View(users);
        }

        [HttpPost]
        public ActionResult SfListesi()
        {
            Proje2Context projeContext = new Proje2Context();

            //List<User> users = projeContext.Users.Where(x => x.ClassId == ClassId).ToList();
            return View();
        }



        [HttpGet]
        public ActionResult TProgram(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class sınıf1 = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == sınıf1.TrainingProgramId).FirstOrDefault();


            ViewBag.ClassId = sınıf.ClassId;
            ViewBag.ClassName = sınıf.ClassName;

            List<Lesson> lesson1 = projeContext.Lessons.Include(x => x.Training).ToList();
            List<SelectListItem> educator = (from i in projeContext.Educators.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.EducatorFullName,
                                                 Value = i.EducatorId.ToString()
                                             }).ToList();
            ViewBag.Educators = educator;
            Lesson lesson = projeContext.Lessons.Where(x => x.TrainingId != null).FirstOrDefault();

            List<SelectListItem> training = (from i in projeContext.Lessons.Where(x => x.TrainingId == sınıf.TrainingId).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.LessonName,
                                                 Value = i.LessonId.ToString()
                                             }).ToList();
            ViewBag.Lessons = training;

            return View(trainingProgramDetail);
        }

        [HttpGet]
        public ActionResult SonuProgram(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class sınıf1 = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == sınıf1.TrainingProgramId).FirstOrDefault();


            ViewBag.ClassId = sınıf.ClassId;
            ViewBag.ClassName = sınıf.ClassName;

            List<Lesson> lesson1 = projeContext.Lessons.Include(x => x.Training).ToList();
            List<SelectListItem> educator = (from i in projeContext.Educators.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.EducatorFullName,
                                                 Value = i.EducatorId.ToString()
                                             }).ToList();
            ViewBag.Educators = educator;

            Lesson lesson = projeContext.Lessons.Where(x => x.TrainingId != null).FirstOrDefault();

            List<SelectListItem> training = (from i in projeContext.Lessons.Where(x => x.TrainingId == sınıf.TrainingId).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.LessonName,
                                                 Value = i.LessonId.ToString()
                                             }).ToList();
            ViewBag.Lessons = training;

            return View(trainingProgramDetail);
        }

        public JsonResult GetTrainingProgramsByClass(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            Class sınıf1 = projeContext.Classes.Where(x => x.ClassId == sınıf.ClassId).FirstOrDefault();

            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == sınıf1.TrainingProgramId).ToList();
            return Json(trainingProgramDetails);
        }

        [HttpGet]
        public ActionResult SProgram()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Class> sınıflar = projeContext.Classes.ToList();

            return View(sınıflar);
        }

        [HttpPost]
        public JsonResult AddOrUpdateTrainingProgramDetail(AddOrUpdateTrainingProgram model)
        {
            Proje2Context projeContext = new Proje2Context();

            Lesson lesson = projeContext.Lessons.Where(x => x.LessonId == model.LessonId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == model.ClassId).FirstOrDefault();
            bool control = projeContext.TrainingProgramDetail.Any(x => x.StartDate >= model.StartDate && x.EndDate <= model.EndDate && x.EducatorId == model.EducatorId && x.StartDate <= model.StartDate && x.EndDate >= model.EndDate);
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingId == sınıf.TrainingId).FirstOrDefault();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == trainingProgram.TrainingId).FirstOrDefault();
            if (model.StartDate > training.TrainingStartdate && model.EndDate > training.TrainingLastdate)
            {
                return Json("1");
            }
            if (model.StartDate < training.TrainingStartdate && model.EndDate < training.TrainingLastdate)
            {
                return Json("1");
            }
            if (model.StartDate == training.TrainingStartdate && model.EndDate < training.TrainingLastdate)
            {
                return Json("1");
            }
            if (control != false)
            {
                //TempData["AlertMessage"] = "Eklemek istediğiniz eğitimcinin başka eğitimi var!...!";
                return Json("2");
            }
            int toplam1 = 0;
            toplam1 = model.EndDate.Hour - model.StartDate.Hour;

            if (training.TotalHours < toplam1 && training.TotalHours == toplam1)
            {
                return Json("19");
            }


            int aralık = 0;
            int toplam = 0;
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.AsNoTracking().Where(x => x.TrainingProgramId == trainingProgram.TrainingProgramId).ToList();

            foreach (var t in trainingProgramDetails)
            {
                aralık = t.EndDate.Hour - t.StartDate.Hour;
                toplam = toplam + toplam1;
                toplam = toplam + aralık;
                if (training.TotalHours < toplam && training.TotalHours == toplam)
                {
                    return Json("19");
                }
            }

            if (model.TrainingProgramDetailId == 0)
            {
                if (model.StartDate < DateTime.Now)
                {
                    return Json("11");
                }
                TrainingProgramDetail trainingProgramDetail = new TrainingProgramDetail()
                {

                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Description = model.Description,
                    TrainingProgramId = sınıf.TrainingProgramId,
                    EducatorId = model.EducatorId,
                    LessonId = lesson.LessonId,
                };

                if (model.EducatorId == 0)
                {
                    //trainingProgramDetail.EducatorFullName = " ";
                    trainingProgramDetail.EducatorId = 0;
                }
                else
                {
                    trainingProgramDetail.EducatorId = model.EducatorId;
                    //trainingProgram.EducatorFullName = training.EducatorFullName;
                }
                projeContext.Add(trainingProgramDetail);
                int sonuc = projeContext.SaveChanges();

            }
            else
            {
                Attendance attendance = projeContext.Attendance.Where(x => x.TrainingProgramDetailId == model.TrainingProgramDetailId).FirstOrDefault();
                if (attendance != null)
                {
                    return Json("7");
                }
                if (model.StartDate < DateTime.Now)
                {
                    return Json("9");
                }
                Educator educator = projeContext.Educators.Where(x => x.EducatorId == model.EducatorId).FirstOrDefault();
                TrainingProgramDetail trainingProgramDetail1 = projeContext.TrainingProgramDetail.AsNoTracking().Where(x => x.TrainingProgramId == model.TrainingProgramId).FirstOrDefault();
                if (trainingProgramDetail1 == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                trainingProgramDetail1.TrainingProgramDetailId = model.TrainingProgramDetailId;
                trainingProgramDetail1.StartDate = model.StartDate;
                trainingProgramDetail1.EndDate = model.EndDate;
                trainingProgramDetail1.Description = model.Description;
                trainingProgramDetail1.TrainingProgramId = trainingProgram.TrainingProgramId;
                trainingProgramDetail1.LessonId = lesson.LessonId;


                projeContext.TrainingProgramDetail.Update(trainingProgramDetail1);
                int sonuc2 = projeContext.SaveChanges();
            }
            
            return Json("200");

        }


       

        public JsonResult GetTrainingProgramsByClassS(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            Class sınıf1 = projeContext.Classes.Where(x => x.ClassId == sınıf.ClassId).FirstOrDefault();

            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == sınıf1.TrainingProgramId).ToList();
            return Json(trainingProgramDetails);
        }

    }
}



