using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Lesson> lessons = projeContext.Lessons.Where(x => x.TrainingId == TrainingId).ToList();
            ViewBag.TrainingId = TrainingId;
            return View(lessons);
        }


        [HttpGet]
        public ActionResult Add(int trainingId)
        {
            ViewBag.TrainingId = trainingId;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Lesson model)
        {
            model.LessonId = 0;
            Proje2Context projeContext = new Proje2Context();
            Training training = new Training();

            LessonValidator lessonValidator = new LessonValidator();
            ValidationResult results = lessonValidator.Validate(model);
            if (!results.IsValid)
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;
                    
                }
                return Json(message);
            }
            _lessonService.Add(model);
            return Json("200");
        }


        [HttpGet]
        public ActionResult Update(int lessonId)
        {
            Proje2Context projeContext = new Proje2Context();
            var result = _lessonService.GetById(lessonId);
            //List<SelectListItem> egitmen = (from i in projeContext.Titles.ToList()
            //                                select new SelectListItem
            //                                {
            //                                    Text = i.TitleName,
            //                                    Value = i.TitleName.ToString()
            //                                }).ToList();
            //ViewBag.Unvan = egitmen;
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Lesson model)
        {
            Proje2Context projeContext = new Proje2Context();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == model.TrainingId).FirstOrDefault();
            Lesson lesson = projeContext.Lessons.Where(x => x.LessonId == model.LessonId).FirstOrDefault();
            model.TrainingId = lesson.TrainingId;
            LessonValidator lessonValidator = new LessonValidator();
            ValidationResult results = lessonValidator.Validate(model);
            if (!results.IsValid)
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;

                }
                return Json(message);
            }
            _lessonService.Update(model);
            return Json("200");
            
        }

        [HttpGet]
        public ActionResult Delete(int LessonId)
        {
            Proje2Context projeContext = new Proje2Context();
            Lesson lessons = projeContext.Lessons.Where(x => x.LessonId == LessonId).FirstOrDefault();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == lessons.TrainingId).FirstOrDefault();
            if(training.TrainingStartdate < DateTime.Now && DateTime.Now > training.TrainingLastdate)
            {
                return Json("5");
            }
            _lessonService.Delete(LessonId);
            return Json("200");
        }

    }
}
