using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
    public class WaitingController : Controller
    {
        private readonly IWaitingService _waitingService;
        private readonly ITrainingService _trainingService;

        public WaitingController(IWaitingService siteService)
        {
            _waitingService = siteService;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult TumBas(Waiting model)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Waiting> waitings = projeContext.Waiting.Include(x => x.User).Where(x => x.TrainingId == model.TrainingId && x.Status == 2).ToList();
            return View(waitings);
        }

        public ActionResult AlanK(Waiting model)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Waiting> waitings = projeContext.Waiting.Include(x => x.User).Where(x => x.TrainingId == model.TrainingId && x.Status == 1 && x.User.ClassId == null).ToList();
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingId == model.TrainingId).FirstOrDefault();
            if(trainingProgram != null)
            {
                List<SelectListItem> sınıf = (from i in projeContext.Classes.Where(x => x.TrainingId == model.TrainingId && x.Kota != 0).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.ClassName,
                                                  Value = i.ClassId.ToString()
                                              }).ToList();
                ViewBag.Classes = sınıf;
            }
            return View(waitings);
        }
        [HttpGet]
        public ActionResult Onayla(int WaitingId)
        {
            Proje2Context projeContext = new Proje2Context();
            Waiting waiting = projeContext.Waiting.Where(x => x.WaitingId == WaitingId).FirstOrDefault();           
            Training training = projeContext.Trainings.Where(x => x.TrainingId == waiting.TrainingId).FirstOrDefault();

            if (training.kota == 0)
            {
                return Json("1");
            }
            if(waiting.UserId != null)
            {
                User user = projeContext.Users.Where(x => x.UserId == waiting.UserId).FirstOrDefault();
                Class sınıf2 = projeContext.Classes.Include(x=>x.Training).Where(x => x.ClassId == user.ClassId).FirstOrDefault();
                Waiting waiting1 = projeContext.Waiting.Include(x => x.Training).Where(x => x.UserId == user.UserId && x.Status == 1).FirstOrDefault();
                if (waiting1 != null)
                {
                    if (waiting1.Training.TrainingLastdate >= training.TrainingStartdate)
                    {
                        return Json("2");
                    }
                }
                if (sınıf2 != null)
                {
                    if (sınıf2.Training.TrainingLastdate >= training.TrainingStartdate)
                    {
                        return Json("3");
                    }
                }
                
            }
            training.kota--;
            projeContext.Update(training);
            int sonuc = projeContext.SaveChanges();
            waiting.Status = 1;
            _waitingService.Update(waiting);
            TempData["AlertMessage"] = "Eğitimi onayladınız...!";
            return Json("200");
        }


        public ActionResult Onaylanmıs(int userId)
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            List<Waiting> waitings = projeContext.Waiting.Include(x => x.Lesson).Where(x => x.UserId == user.UserId && x.Status == 1).ToList();
            //List<Training> trainings = projeContext.Trainings.Where(x=>x.TrainingId == )
            List<Waiting> waiting1 = projeContext.Waiting.Include(x => x.Training).ToList();
            List<Waiting> waitings2 = projeContext.Waiting.Include(x => x.Training).ToList();
            ViewBag.MessageContext = HttpContext.Session.GetString("MessageContext");
            return View(waitings);
        }

        

        public ActionResult Beklenen()
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x=>x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            List<Waiting> waiting = projeContext.Waiting.Include(x => x.Lesson).Where(x => x.UserId == user.UserId && x.Status == 2).ToList();
            List<Waiting> waiting1 = projeContext.Waiting.Include(x => x.Training).ToList();
            //List<Waiting> waitings = projeContext.Waiting.Where(x => x.UserId == user.UserId && x.Status == 2).ToList();
            return View(waiting);
        }

        public ActionResult Reddet()
        {
            HttpContext.Session.GetString("UserName");
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            List<Waiting> waitings = projeContext.Waiting.Include(x => x.Lesson).Where(x => x.UserId == user.UserId && x.Status == 3).ToList();
            List<Waiting> waiting1 = projeContext.Waiting.Include(x => x.Training).ToList();
            return View(waitings);
        }

        [HttpGet]
        public ActionResult Delete(int WaitingId)
        {
            Proje2Context projeContext = new Proje2Context();
            var result = _waitingService.GetById(WaitingId);
            Waiting waiting = projeContext.Waiting.Where(x => x.WaitingId == WaitingId).FirstOrDefault();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == waiting.TrainingId).FirstOrDefault();
            //_waitingService.Delete(waiting.WaitingId);
            training.kota++;
            projeContext.Update(training);
            int sonuc = projeContext.SaveChanges();
            _waitingService.Delete(waiting.WaitingId);
            return Json("200");
        }
        public ActionResult Gonder(Waiting waiting)
        {
            Proje2Context projeContext = new Proje2Context();
            Waiting waiting1 = projeContext.Waiting.Where(x => x.WaitingId == waiting.WaitingId).FirstOrDefault();
            waiting1.MessageContext = waiting.MessageContext;
            waiting1.Status = 3;
            _waitingService.Update(waiting1);
            TempData["AlertMessage"] = "Mesajınız gönderildi...!";
            return Json("200");
        }

     

       

    }
}
