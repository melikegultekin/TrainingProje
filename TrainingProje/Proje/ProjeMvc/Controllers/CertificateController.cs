using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Training> trainings = projeContext.Trainings.ToList();
            
            return View(trainings);
        }
        public ActionResult Add()
        {
            Proje2Context projeContext = new Proje2Context();
            List<SelectListItem> unvanlar = (from i in projeContext.Titles.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.TitleName,
                                                 Value = i.TitleId.ToString()
                                             }).ToList();
            ViewBag.Titles = unvanlar;

            List<SelectListItem> eğitmenler = (from i in projeContext.Educators.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.EducatorFullName,
                                                 Value = i.EducatorId.ToString()
                                             }).ToList();
            ViewBag.Educators = eğitmenler;

            List<SelectListItem> training = (from i in projeContext.Trainings.Where(x=>x.TrainingLastdate>DateTime.Today).ToList()
                                             select new SelectListItem
                                             {
                                                 //Text = i.TrainingName,
                                                 Value = i.TrainingId.ToString()
                                             }).ToList();
            ViewBag.Trainings = training;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Certificate model)
        {
            model.CertificateId = 0;
            Proje2Context projeContext = new Proje2Context();
            _certificateService.Add(model);
            TempData["AlertMessage"] = "Sertifika ekleme işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Certificate");
        }

        [HttpGet]
        public ActionResult SL(int TrainingId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Exam> exams = projeContext.Exams.Include(x => x.User).Where(x => x.TrainingId == TrainingId && x.Status == 1).ToList();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == TrainingId).FirstOrDefault();
            ViewBag.eğitim = training.TrainingName;
            return View(exams);
        }

        [HttpGet]
        public ActionResult SBelgesi(Exam model)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Exam> exams = projeContext.Exams.Include(x => x.Training).Where(x => x.TrainingId == model.TrainingId).ToList();
            //List<Waiting> waitings = projeContext.Waiting.Where(x => x.TrainingId == TrainingId && x.Status ==1).ToList();
            Exam exam = projeContext.Exams.Include(x => x.User).Where(x => x.UserId == model.UserId).FirstOrDefault();
            
            return View(exam);
        }


        [HttpGet]
        public ActionResult Sonuc(int examId)
        {
            Proje2Context projeContext = new Proje2Context();
            Exam exam = projeContext.Exams.Where(x => x.ExamId == examId).FirstOrDefault();
            if(exam.ExamNot == null)
            {
                return Json("202");
            }
            if(exam.ExamNot < 60)
            {
                return Json("201");
            }
            return Json("200");
        }
    }
}
