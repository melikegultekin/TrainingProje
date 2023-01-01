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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Controllers
{
    public class TrainingProgramDetailController : Controller
    {
        private readonly ITrainingProgramDetailService _trainingProgramDetailService;

        public TrainingProgramDetailController(ITrainingProgramDetailService trainingProgramDetailService)
        {
            _trainingProgramDetailService = trainingProgramDetailService;
        }


        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Training> trainings = projeContext.Trainings.ToList();
            return View(trainings);
        }
        [HttpPost]
        public JsonResult AddOrUpdateTrainingProgram(AddOrUpdateTrainingProgram model)
        {
            Proje2Context projeContext = new Proje2Context();
            Attendance attendance = projeContext.Attendance.Where(x => x.TrainingProgramDetailId == model.TrainingProgramDetailId).FirstOrDefault();
            if(attendance != null)
            {
                return Json("1");
            }
            if(model.StartDate<DateTime.Now)
            {
                TempData["AlertMessage"] = "Bugünün tarihinden önce program eklenemez...!";
                return Json("200");
            }
            Training training = projeContext.Trainings.Where(x => x.TrainingId == model.TrainingId).FirstOrDefault();
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingId == model.TrainingId).FirstOrDefault();
            if (model.TrainingProgramDetailId == 0)
            {
                TrainingProgramDetail trainingProgramDetail = new TrainingProgramDetail()
                {
                    TrainingProgramDetailId = model.TrainingProgramDetailId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Description = model.Description,
                    EducatorId = model.EducatorId,
                    LessonId = model.LessonId,
                    TrainingProgramId = trainingProgram.TrainingProgramId,
                    
                };
                _trainingProgramDetailService.Add(trainingProgramDetail);

            }
            else
            {
                var entity = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramDetailId == model.TrainingProgramDetailId).FirstOrDefault();
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                entity.TrainingProgramDetailId = model.TrainingProgramDetailId;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.TrainingProgramDetailId = model.TrainingProgramDetailId;
                entity.Description = model.Description;
                entity.TrainingProgramId = trainingProgram.TrainingProgramId;

                _trainingProgramDetailService.Update(entity);
            }

            return Json("200");

        }

        [HttpPost]
        public ActionResult Add(TrainingProgramDetail trainingProgramDetail)
        {
            trainingProgramDetail.TrainingProgramDetailId = 0;
            Proje2Context projeContext = new Proje2Context();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == trainingProgramDetail.TrainingProgramId).FirstOrDefault();
            TrainingProgramDetail trainingProgrammDetail = new TrainingProgramDetail();
            if (trainingProgramDetail.TrainingProgramId == 0)
            {
                trainingProgrammDetail.StartDate = trainingProgramDetail.StartDate;
                trainingProgrammDetail.EndDate = trainingProgramDetail.EndDate;
                trainingProgrammDetail.Description = trainingProgramDetail.Description;
                trainingProgrammDetail.EducatorId = trainingProgramDetail.EducatorId;
                trainingProgrammDetail.TrainingProgramId = trainingProgramDetail.TrainingProgramId;
                

                _trainingProgramDetailService.Add(trainingProgrammDetail);
            }
            else
            {
                var entity = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == trainingProgramDetail.TrainingProgramId).FirstOrDefault();
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                entity.TrainingProgramId = trainingProgramDetail.TrainingProgramId;
                entity.StartDate = trainingProgramDetail.StartDate;
                entity.EndDate = trainingProgramDetail.EndDate;
                //entity.TrainingId = trainingProgramDetail.TrainingId;
                entity.Description = trainingProgramDetail.Description;

                _trainingProgramDetailService.Update(entity);
            }
            
            return RedirectToAction(actionName: "Authorized", controllerName: "User");
        }

        [HttpGet]
        public ActionResult Update(int trainingProgramId)
        {
            var result = _trainingProgramDetailService.GetById(trainingProgramId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(TrainingProgramDetail model)
        {
            Proje2Context projeContext = new Proje2Context();
            TrainingProgramDetail trainingProgrammDetail = new TrainingProgramDetail()
            {
                
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description,
                EducatorId = model.EducatorId,
                LessonId = model.LessonId,

            };
            _trainingProgramDetailService.Update(model);

            TempData["AlertMessage"] = "Güncelleme işleminiz başarılı...!";
            return RedirectToAction(actionName: "Authorized", controllerName: "User");
        }


        public JsonResult Delete(int trainingProgramId)
        {
            Proje2Context projeContext = new Proje2Context();
            var entity = projeContext.TrainingPrograms.SingleOrDefault(x => x.TrainingProgramId == trainingProgramId);
            if (entity == null)
            {
                return Json("Kayıt bulunamadı.");
            }
            projeContext.Remove(entity);
            projeContext.SaveChanges();
            return Json("200");
        }

        [HttpGet]
        public IActionResult Program(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            TrainingProgram trainingPrograms = projeContext.TrainingPrograms.Where(x => x.TrainingId == TrainingId).FirstOrDefault();
            
            List<SelectListItem> educator = (from i in projeContext.Educators.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.EducatorFullName,
                                                 Value = i.EducatorId.ToString()
                                             }).ToList();
            ViewBag.Educators = educator;
            List<SelectListItem> training = (from i in projeContext.Trainings.ToList()
                                             select new SelectListItem
                                             {
                                                 //Text = i.TrainingName,
                                                 Value = i.TrainingId.ToString()
                                             }).ToList();
            ViewBag.Trainings = training;

            List<SelectListItem> sınıflar = (from i in projeContext.Classes.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.ClassName,
                                              Value = i.ClassId.ToString()
                                          }).ToList();
            ViewBag.Classes = sınıflar;

            return View(trainingPrograms);
        }

        [HttpPost]
        public IActionResult Program(TrainingProgramDetail model)
        {
            model.TrainingProgramDetailId = 0;
            Proje2Context projeContext = new Proje2Context();
            TrainingProgramDetail trainingProgramDetail = new TrainingProgramDetail();
            
            projeContext.TrainingProgramDetail.Add(model);
            int sonuc = projeContext.SaveChanges();
            TempData["AlertMessage"] = "Ekleme işleminiz başarılı...!";
            return View();
        }

        public ActionResult GetTrainingProgramByEducator(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            //List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Where(x => x.EducatorId == educatorId).ToList();
            var model = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == EducatorId).FirstOrDefault();
            return View(model);
        }
        public JsonResult GetTrainingProgramByTraining(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Where(x => x.TrainingId == TrainingId).ToList();
            return Json(trainingPrograms);
        }

        public JsonResult DeleteP(int trainingProgramDetailId)
        {
            Proje2Context projeContext = new Proje2Context();
            var entity = projeContext.TrainingProgramDetail.SingleOrDefault(x => x.TrainingProgramDetailId == trainingProgramDetailId);
            Attendance attendance = projeContext.Attendance.Where(x => x.TrainingProgramDetailId == trainingProgramDetailId).FirstOrDefault();
            if (entity == null)
            {
                return Json("Kayıt bulunamadı.");
            }
            if(attendance != null)
            {
                projeContext.Attendance.Remove(attendance);
                int sonuc = projeContext.SaveChanges();
            }
            projeContext.TrainingProgramDetail.Remove(entity);
            int sonuc1 = projeContext.SaveChanges();
            return Json("200");
        }
    }
}








