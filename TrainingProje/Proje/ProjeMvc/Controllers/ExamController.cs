using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
    public class ExamController : Controller
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            ViewBag.username = HttpContext.Session.GetString("ManagerName");
            Proje2Context projeContext = new Proje2Context();
            List<Lesson> lessons = projeContext.Lessons.Include(x => x.Training).ToList();
            List<Training> trainings = projeContext.Trainings.ToList();
            //List<int> exams = projeContext.Exams.Include(x => x.User).Where(x => x.Status != 0 ).Select(x => x.Training.TrainingId).ToList();
            //List<Training> trainings = projeContext.Trainings.Where(exams.Contains(x=>x.TrainingId)).ToList();
            List<Training> trainings1 = new List<Training>();
            foreach (var t in trainings)
            {
                Exam exam = projeContext.Exams.Where(x => x.TrainingId == t.TrainingId).FirstOrDefault();

                if (exam == null)
                {
                    trainings1.Add(t);
                }

            }
            return View(trainings1);
        }

        public IActionResult Sınavlar()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Exam> sınavlar = projeContext.Exams.Include(x => x.Training).Where(x => x.Status == 3).ToList();
            return View(sınavlar);
        }

        public IActionResult Notlar(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Exam> sınavlar = projeContext.Exams.Include(x => x.Training).Where(x => x.Status != 3).ToList();
            return View(sınavlar);
        }

        [HttpGet]
        public IActionResult Add(Exam model)
        {
            Proje2Context projeContext = new Proje2Context();
            Exam exam = new Exam();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == model.TrainingId).FirstOrDefault();
            List<Class> sınıflar = projeContext.Classes.Where(x => x.TrainingId == model.TrainingId).ToList();
            List<User> users = projeContext.Users.Where(x => x.Class.TrainingId == model.TrainingId).ToList();
            List<Lesson> lessons = projeContext.Lessons.Where(x => x.TrainingId == model.TrainingId).ToList();
            int s = 0;
            foreach (var l in lessons)
            {
                
                if (l != null)
                {
                    s++;
                }
                
            }
            if (s == 0)
            {
                return Json("5");
            }
            //if (training.TrainingLastdate > DateTime.Now)
            //{
            //    return Json("2");
            //}
            exam.TrainingId = model.TrainingId;
            exam.Status = 3;
            _examService.Add(exam);
            
            
            foreach (var u in users)
            {
                foreach (var sınıf in sınıflar)
                {
                    if (u.ClassId == sınıf.ClassId)
                    {
                        Exam sınav = projeContext.Exams.Where(x => x.TrainingId == sınıf.TrainingId && x.Status == 3).FirstOrDefault();
                        Exam sv = new Exam();
                        sv.UserId = u.UserId;
                        sv.Status = 4;
                        sv.ExamNot = null;
                        sv.ClassId = u.ClassId;
                        sv.TrainingId = model.TrainingId;
                        _examService.Add(sv);
                    }

                }

            }
            return Json("200");
        }

        public IActionResult NotBilgisi(int trainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Class> sınıflar = projeContext.Classes.Where(x => x.TrainingId == trainingId).ToList();
            //List<Exam> exams = projeContext.Exams.ToList();
            //List<Exam> sınavlar1 = projeContext.Exams.Include(x=>x.User).Where(x => x.TrainingId == TrainingId && x.Status == 4).ToList();
            List<Exam> sınavlar1 = projeContext.Exams.Include(x => x.User).Where(x => x.TrainingId == trainingId && x.Status != 3).ToList();
            ViewBag.TrainingId = trainingId;
            

            return View(sınavlar1);
        }

        public IActionResult Kaydet(Exam model)
        {
            Proje2Context projeContext = new Proje2Context();
            Exam sınav = new Exam();
            Exam sv = projeContext.Exams.Where(x => x.ExamId == model.ExamId).FirstOrDefault();
            User user = projeContext.Users.Where(x => x.UserId == sv.UserId).FirstOrDefault();
            Exam exam = projeContext.Exams.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if(exam != null)
            {
                return Json("50");
            }
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            sınav.ClassId = user.ClassId;
            sınav.TrainingId = sınıf.TrainingId;
            sınav.UserId = user.UserId;
            if (model.ExamNot < 60)
            {
                sınav.Status = 2;
            }
            if (model.ExamNot >= 60)
            {
                sınav.Status = 1;
            }
            sınav.ExamNot = model.ExamNot;
            sınav.ExamId = model.ExamId;
            ViewBag.Training = sınıf.TrainingId;
            _examService.Update(sınav);
            return Json("200");
            //return RedirectToAction(actionName: "NotGir", controllerName: "Exam");

        }

        public IActionResult KaydetU(Exam model)
        {
            Proje2Context projeContext = new Proje2Context();
            Exam sınav = new Exam();
            if(model.ExamNot == null)
            {
                return Json("1");
            }
            Exam sv = projeContext.Exams.Where(x => x.ExamId == model.ExamId).FirstOrDefault();
            User user = projeContext.Users.Where(x => x.UserId == sv.UserId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            sınav.ClassId = user.ClassId;
            sınav.TrainingId = sınıf.TrainingId;
            sınav.UserId = user.UserId;
            if (model.ExamNot < 60)
            {
                sınav.Status = 2;
            }
            if (model.ExamNot >= 60)
            {
                sınav.Status = 1;
            }
            sınav.ExamNot = model.ExamNot;
            sınav.ExamId = model.ExamId;
            ViewBag.Training = sınıf.TrainingId;
            _examService.Update(sınav);
            return Json("200");
            //return RedirectToAction(actionName: "NotGir", controllerName: "Exam");

        }

        public ActionResult Duzelt(Exam model)
        {

            Proje2Context projeContext = new Proje2Context();

            ExamValidator examValidator = new ExamValidator();
            ValidationResult results = examValidator.Validate(model);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            _examService.Update(model);
            TempData["AlertMessage"] = "Güncelleme işleminiz başarılı...!";
            return Json("200");
        }


        public IActionResult Haftaİçi(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            return View();
        }

        public IActionResult HaftaSonu(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            return View();
        }

        public ActionResult Sonuc()
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            List<Exam> exams = projeContext.Exams.Include(x => x.Training).ToList();
            List<Exam> sınavlar = projeContext.Exams.Where(x => x.UserId == user.UserId).ToList();
            
            return View(sınavlar);
        }


        [HttpGet]
        public ActionResult Delete(int ExamId)
        {
            Proje2Context projeContext = new Proje2Context();
            Exam exam = projeContext.Exams.Where(x => x.ExamId == ExamId).FirstOrDefault();
            List<Training> trainings = projeContext.Trainings.Where(x => x.TrainingId == exam.TrainingId).ToList();
            foreach (var t in trainings)
            {
                Exam exam1 = projeContext.Exams.Where(x => x.TrainingId == t.TrainingId).FirstOrDefault();
                if(exam1.Status != 3)
                {
                    return Json("5");
                }
            }

            _examService.Delete(ExamId);
            
            return Json("200");
        }
    }
}







