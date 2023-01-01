using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace ProjeMvc.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        private readonly ILessonService _lessonService;

        private readonly IWaitingService _waitingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            Waiting waiting = new Waiting();
            waiting.UserId = user.UserId;
            Training training = new Training();
            List<Training> trainings = projeContext.Trainings.Where(x => x.kota != 0 && x.Trainingdate >= DateTime.Today).ToList();
            List<Waiting> waitings1 = projeContext.Waiting.Include(x => x.User).ToList();
            List<Waiting> waitings = projeContext.Waiting.Where(x => x.UserId == user.UserId).ToList();
            List<Training> training1 = new List<Training>();
            if (waitings != null)
            {
                foreach (var w in trainings)
                {
                    bool eklenecekmi = true;
                    Lesson ders = projeContext.Lessons.Where(x => x.TrainingId == w.TrainingId).FirstOrDefault();
                    if (ders != null)
                    {
                        foreach (var t in waitings)
                        {
                            if (w.TrainingId == t.TrainingId /*&& w.Trainingdate > DateTime.Today*/)
                            {
                                eklenecekmi = false;
                                //break;
                            }
                            if (w.TrainingId == t.TrainingId && w.kota != 0 && t.Status == 3)
                            {

                                training1.Add(w);
                            }
                        }
                        if (eklenecekmi)
                            training1.Add(w);
                    }
                }
            }
            else
            {
                foreach (var w in trainings)
                {
                    Lesson ders = projeContext.Lessons.Where(x => x.TrainingId == w.TrainingId).FirstOrDefault();
                    if (ders != null)
                    {
                        training1 = trainings;
                    }
                }
            }
            return View(training1);
        }



        [HttpGet]
        public ActionResult Add(Educator model)
        {
            Proje2Context projeContext = new Proje2Context();
            //Educator educator = projeContext.Educators.Where(x => x.TitleId == model.TitleId).FirstOrDefault();
            List<SelectListItem> dersler = (from i in projeContext.Lessons.Where(x => x.TrainingId == null).ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.LessonName,
                                                Value = i.LessonId.ToString()
                                            }).ToList();
            ViewBag.Dersler = dersler;
            //Title title = new Title();
            List<SelectListItem> egitmen = (from i in projeContext.Educators.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.EducatorFullName,
                                                Value = i.EducatorId.ToString()
                                            }).ToList();
            ViewBag.Egitmen = egitmen;
            return View();
        }

        [HttpPost]
        public ActionResult Add(TrainingDetailDto trainingDetailDto)
        {
            trainingDetailDto.TrainingId = 0;
            Proje2Context projeContext = new Proje2Context();

            TrainingDetailDtoValidator trainingDetailDtoValidator = new TrainingDetailDtoValidator();
            ValidationResult results = trainingDetailDtoValidator.Validate(trainingDetailDto);
            if (!results.IsValid)
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;
                    return Json(message);
                }
            }
            Training training = new Training();
            training.TrainingId = trainingDetailDto.TrainingId;
            training.kota = trainingDetailDto.kota;
            training.TrainingStartdate = trainingDetailDto.TrainingStartdate;
            training.TrainingLastdate = trainingDetailDto.TrainingLastdate;
            training.Trainingdate = trainingDetailDto.Trainingdate;
            training.TotalHours = trainingDetailDto.TotalHours;
            training.TrainingName = trainingDetailDto.TrainingName;
            _trainingService.Add(training);
            //projeContext.Add(training);
            //int sonuc1 = projeContext.SaveChanges();
            Lesson lesson = projeContext.Lessons.Where(x => x.LessonId == trainingDetailDto.LessonId).FirstOrDefault();
            return Json("200");
            //return RedirectToAction(actionName: "GetAllT", controllerName: "Manager");

        }



        [HttpGet]
        public ActionResult Basvur(Waiting waiting)
        {
            waiting.WaitingId = 0;
            Proje2Context projeContext = new Proje2Context();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == waiting.TrainingId && x.Trainingdate >= DateTime.Today).FirstOrDefault();
            Lesson lesson = projeContext.Lessons.Where(x => x.TrainingId == training.TrainingId).FirstOrDefault();
            User user1 = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            User user = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName") && x.ClassId != null).FirstOrDefault();
            if (user != null)
            {
                return Json("5");
            }
            waiting.UserId = user1.UserId;
            waiting.Status = 2;
            waiting.LessonId = lesson.LessonId;
            projeContext.Add(waiting);
            int sonuc = projeContext.SaveChanges();
            return Json("200");
        }



        [HttpGet]
        public ActionResult Update(int TrainingId)
        {
            var result = _trainingService.GetById(TrainingId);
            ViewBag.TrainingName = result.TrainingName;
            ViewBag.kota = result.kota;
            ViewBag.TrainingStartdate = result.TrainingStartdate;
            ViewBag.TrainingLastdate = result.TrainingLastdate;
            ViewBag.TotalHours = result.TotalHours;
            ViewBag.Trainingdate = result.Trainingdate;
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Training trainingDetailDto)
        {

            Proje2Context projeContext = new Proje2Context();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == trainingDetailDto.TrainingId).FirstOrDefault();
            if (training.TrainingStartdate < DateTime.Now && DateTime.Now > training.TrainingLastdate)
            {
                return Json("5");
            }
            TrainingValidator trainingValidator = new TrainingValidator();
            ValidationResult results = trainingValidator.Validate(trainingDetailDto);

            if (!results.IsValid)
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;
                }
                return Json(message);
            }
            _trainingService.Update(trainingDetailDto);
            Waiting waiting = projeContext.Waiting.Where(x => x.TrainingId == trainingDetailDto.TrainingId).FirstOrDefault();
            return Json("200");
        }




        [HttpGet]
        public ActionResult Delete(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            Waiting waiting = projeContext.Waiting.Where(x => x.TrainingId == TrainingId).FirstOrDefault();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == TrainingId).FirstOrDefault();
            if(training.TrainingStartdate < DateTime.Now && training.TrainingLastdate > DateTime.Now)
            {
                return Json("1");
            }
            List<Waiting> waitings = projeContext.Waiting.Where(x => x.TrainingId == TrainingId).ToList();
            foreach (var w in waitings)
            {
                if(w !=null)
                {
                    if(w.Status == 2)
                    {
                        return Json("2");
                    }
                    if(w.Status == 1)
                    {
                        return Json("3");
                    }
                }
            }
            List<TrainingProgram> trainingProgramss = projeContext.TrainingPrograms.Where(x => x.TrainingId == TrainingId).ToList();
            foreach (var t in trainingProgramss)
            {
                if(t != null)
                {
                    return Json("4");
                }
            }
            if (waiting != null)
            {
                if (waiting.Status != 0)
                {
                    projeContext.Waiting.Remove(waiting);
                    int sonuc = projeContext.SaveChanges();
                }
            }
            List<Lesson> dersler = projeContext.Lessons.Where(x => x.TrainingId == TrainingId).ToList();
            foreach (var l in dersler)
            {
                projeContext.Lessons.Remove(l);
                int sonuc = projeContext.SaveChanges();
            }
            List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Where(x => x.TrainingId == TrainingId).ToList();
            foreach (var t in trainingPrograms)
            {
                projeContext.TrainingPrograms.Remove(t);
                int sonuc = projeContext.SaveChanges();
                List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == t.TrainingProgramId).ToList();
                foreach (var tP in trainingProgramDetails)
                {
                    projeContext.TrainingProgramDetail.Remove(tP);
                    int sonuc1 = projeContext.SaveChanges();
                }
            }

            _trainingService.Delete(TrainingId);
            return Json("200");
        }

        public ActionResult Dersler(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Lesson> dersler = projeContext.Lessons.Where(x => x.TrainingId == TrainingId).ToList();
            return View(dersler);
        }

    }

}
