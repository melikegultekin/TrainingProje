using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Yoklama(int TrainingProgramDetailId)
        {
            Proje2Context projeContext = new Proje2Context();
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramDetailId == TrainingProgramDetailId).FirstOrDefault();
            if (trainingProgramDetail.StartDate < DateTime.Today)
            {
                return Json("1");
            }
            if (trainingProgramDetail.StartDate > DateTime.Today)
            {
                return Json("1");
            }
            if (trainingProgramDetail.StartDate < DateTime.Now && DateTime.Now > trainingProgramDetail.EndDate)
            {
                return Json("1");
            }

            Class sınıflar = projeContext.Classes.Where(x => x.TrainingProgramId == trainingProgramDetail.TrainingProgramId).FirstOrDefault();
            //List<int> attendances = projeContext.Attendance.Include(x=>x.User).Where(x => x.Status == "+" && x.Status == "-" && x.ClassId == sınıflar.ClassId && x.TrainingProgramDetailId == TrainingProgramDetailId).Select(x=>x.User.UserId).ToList();
            List<int> attendances = projeContext.Attendance.Include(x => x.User).Where(x => x.Status != null && x.ClassId == sınıflar.ClassId && x.TrainingProgramDetailId == TrainingProgramDetailId).Select(x => x.User.UserId).ToList();
            List<User> users = projeContext.Users.Where(x => x.ClassId == sınıflar.ClassId && !attendances.Contains(x.UserId) ).ToList();
           
            ViewBag.TrainingProgramDetail = trainingProgramDetail.TrainingProgramDetailId;
            return Json("200");
        }

        [HttpGet]
        public ActionResult SınıfYoklama(int TrainingProgramDetailId)
        {
            Proje2Context projeContext = new Proje2Context();
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramDetailId == TrainingProgramDetailId).FirstOrDefault();
            
            Class sınıflar = projeContext.Classes.Where(x => x.TrainingProgramId == trainingProgramDetail.TrainingProgramId).FirstOrDefault();
            List<int> attendances = projeContext.Attendance.Include(x => x.User).Where(x => x.Status != null && x.ClassId == sınıflar.ClassId && x.TrainingProgramDetailId == TrainingProgramDetailId).Select(x => x.User.UserId).ToList();
            List<User> users = projeContext.Users.Where(x => x.ClassId == sınıflar.ClassId && !attendances.Contains(x.UserId)).ToList();

            ViewBag.TrainingProgramDetail = trainingProgramDetail.TrainingProgramDetailId;

            return View(users);
        }


        [HttpGet]
        public ActionResult AddE(int trainingProgramDetailId , int userId)
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            Attendance attendance = new Attendance();
            attendance.ClassId = sınıf.ClassId;
            attendance.TrainingProgramDetailId = trainingProgramDetailId;
            attendance.UserId = user.UserId;
            ViewBag.TrainingProgramDetail1 = trainingProgramDetailId;
            attendance.Status = "+";
            _attendanceService.Add(attendance);
            return Json("200");
        }

        [HttpGet]
        public ActionResult AddH(int trainingProgramDetailId, int userId)
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            Attendance attendance = new Attendance();
            attendance.ClassId = sınıf.ClassId;
            attendance.TrainingProgramDetailId = trainingProgramDetailId;
            attendance.UserId = user.UserId;
            attendance.Status = "-";
            _attendanceService.Add(attendance);
            return Json("200");
        }

        [HttpGet]
        public ActionResult Update(int userId)
        {
            Proje2Context projeContext = new Proje2Context();
            var entity = projeContext.Attendance.Where(x => x.UserId == userId).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YoklamaDurumu(int UserId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Attendance> attendance1 = projeContext.Attendance.Include(x => x.TrainingProgramDetail).ToList();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Include(x => x.Lesson).ToList();
            List<TrainingProgramDetail> trainingProgramDetails1 = projeContext.TrainingProgramDetail.Include(x => x.Educator).ToList();
            List<Attendance> attendance = projeContext.Attendance.Where(x => x.UserId == UserId).ToList();
            User user = projeContext.Users.Where(x => x.UserId == UserId).FirstOrDefault();
            
            ViewBag.Sınıf = user.ClassId;
            return View(attendance);
        }

        [HttpGet]
        public ActionResult YoklamaDurumuE(int UserId)
        {
            Proje2Context projeContext = new Proje2Context();
            List<Attendance> attendance1 = projeContext.Attendance.Include(x => x.TrainingProgramDetail).ToList();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Include(x => x.Lesson).ToList();
            List<TrainingProgramDetail> trainingProgramDetails1 = projeContext.TrainingProgramDetail.Include(x => x.Educator).ToList();
            List<Attendance> attendance = projeContext.Attendance.Where(x => x.UserId == UserId).ToList();
            
            User user = projeContext.Users.Where(x => x.UserId == UserId).FirstOrDefault();
            ViewBag.UserName = user.UserName;
            return View(attendance);
        }

        [HttpGet]
        public ActionResult UpdateE(int attendanceId)
        {
            Proje2Context projeContext = new Proje2Context();
            Attendance attendance1 = projeContext.Attendance.Where(x => x.AttendanceId == attendanceId).FirstOrDefault();
            User user = projeContext.Users.Where(x => x.UserId == attendance1.UserId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            Attendance attendance = new Attendance();
            attendance.ClassId = sınıf.ClassId;
            attendance.TrainingProgramDetailId = attendance1.TrainingProgramDetailId;
            attendance.UserId = user.UserId;
            ViewBag.TrainingProgramDetail1 = attendance1.TrainingProgramDetailId;
            ViewBag.User = attendance1.UserId;
            attendance.Status = "+";
            attendance.AttendanceId = attendanceId;
            _attendanceService.Update(attendance);
            return Json("200");
        }

        [HttpGet]
        public ActionResult UpdateH(int attendanceId)
        {
            Proje2Context projeContext = new Proje2Context();
            Attendance attendance1 = projeContext.Attendance.Where(x => x.AttendanceId == attendanceId).FirstOrDefault();
            User user = projeContext.Users.Where(x => x.UserId == attendance1.UserId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            Attendance attendance = new Attendance();
            attendance.ClassId = sınıf.ClassId;
            attendance.TrainingProgramDetailId = attendance1.TrainingProgramDetailId;
            attendance.UserId = user.UserId;
            attendance.AttendanceId = attendanceId;
            attendance.Status = "-";
            _attendanceService.Update(attendance);
            return Json("200");
        }
    }
}
