using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeMvc.Controllers
{
    public class TrainingProgramController : Controller
    {
        private readonly ITrainingProgramService _trainingProgramService;

        private readonly IClassService _classService;

        public TrainingProgramController(ITrainingProgramService trainingProgramService)
        {
            _trainingProgramService = trainingProgramService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            //trainingProgram.TrainingProgramId = 0;
            Proje2Context projeContext = new Proje2Context();


            return View();
        }

        [HttpPost]
        public ActionResult Add(TrainingProgramDto trainingProgramDto)
        {
            trainingProgramDto.TrainingProgramId = 0;
            trainingProgramDto.ClassId = 0;
            Proje2Context projeContext = new Proje2Context();
            List<Class> sınıflar1 = projeContext.Classes.Where(x => x.TrainingId == trainingProgramDto.TrainingId).ToList();
            TrainingProgram trainingProgram2 = projeContext.TrainingPrograms.Include(x => x.Training).Where(x => x.TrainingId == trainingProgramDto.TrainingId).FirstOrDefault();
            Training training3 = projeContext.Trainings.Where(x => x.TrainingId == trainingProgramDto.TrainingId).FirstOrDefault();
            Lesson lessons = projeContext.Lessons.Where(x => x.TrainingId == trainingProgramDto.TrainingId).FirstOrDefault();
            if (trainingProgramDto.Kota > 100)
            {
                return Json("17");
            }
            if (trainingProgramDto.Name == null)
            {
                return Json("7");
            }
            if (lessons == null)
            {
                return Json("11");
            }
            if (training3 == null)
            {
                return Json("10");
            }
            if (training3 != null)
            {
                if (DateTime.Now > training3.TrainingLastdate)
                {
                    return Json("5");
                }
            }

            Training training2 = projeContext.Trainings.Where(x => x.TrainingId == trainingProgramDto.TrainingId).FirstOrDefault();
            
            Lesson lesson1 = projeContext.Lessons.Include(x => x.Training).FirstOrDefault();
            List<Lesson> dersler = projeContext.Lessons.Where(x => x.TrainingId == trainingProgramDto.TrainingId).ToList();
            foreach (var d in dersler)
            {
                int s = 0;
                if (d != null)
                {
                    s++;
                }
                if (s == 0)
                {
                    return Json("6");
                }

            }
          
            TrainingProgram trainingProgram1 = new TrainingProgram();
            trainingProgram1.TrainingId = trainingProgramDto.TrainingId;
            trainingProgram1.Name = trainingProgramDto.Name;
            Training training = projeContext.Trainings.Where(x => x.TrainingId == trainingProgramDto.TrainingId).FirstOrDefault();
            List<Class> sınıflar = projeContext.Classes.Where(x => x.ClassName == trainingProgramDto.ClassName).ToList();
            if (trainingProgramDto.ClassName == null && trainingProgramDto.Kota != 0)
            {
                return Json("3");
            }
            

            foreach (var s in sınıflar)
            {
                TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == s.TrainingProgramId).FirstOrDefault();
                if (trainingProgram != null)
                {

                    if (trainingProgram.Name == trainingProgramDto.Name)
                    {
                        return Json("2");
                    }
                    if (s.ClassName == trainingProgramDto.ClassName && s.TrainingId != trainingProgramDto.TrainingId)
                    {
                        return Json("2");
                    }
                }

            }
            projeContext.Add(trainingProgram1);
            int sonuc1 = projeContext.SaveChanges();
            Class sınıf = new Class();
            if (trainingProgramDto.ClassName == null)
            {

                sınıf.ClassName = trainingProgramDto.ClassName;
            }
            else
            {
                sınıf.ClassName = trainingProgramDto.ClassName;
            }
            sınıf.TrainingId = trainingProgramDto.TrainingId;
            sınıf.Kota = trainingProgramDto.Kota;
            sınıf.TrainingProgramId = trainingProgram1.TrainingProgramId;
            projeContext.Classes.Add(sınıf);
            int sonuc = projeContext.SaveChanges();
            return Json("200");
        }

        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            //TrainingProgram trainingProgram = projeContext.TrainingPrograms.Include(x => x.Training).FirstOrDefault();
            List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Include(x => x.Training).Where(x => x.Name == 1).ToList();

            List<SelectListItem> lesson = (from i in projeContext.Trainings.Where(x => x.TrainingName != null).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TrainingName,
                                               Value = i.TrainingId.ToString()
                                           }).ToList();
            ViewBag.Lessons = lesson;
            List<Class> sınıflar = projeContext.Classes.ToList();
            List<Class> sınıflar1 = new List<Class>();
            foreach (var t in trainingPrograms)
            {
                foreach (var s in sınıflar)
                {
                    if (t.TrainingProgramId == s.TrainingProgramId)
                    {
                        sınıflar1.Add(s);
                    }
                }
            }
            List<Class> sınıflar3 = projeContext.Classes.Include(x => x.Training).ToList();
            List<Class> sınıflar2 = projeContext.Classes.Include(x => x.TrainingProgram).ToList();
            
            return View(sınıflar1);
        }


        public ActionResult GetAllS()
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Include(x => x.Training).Where(x => x.Name == 2).ToList();

            List<SelectListItem> lesson = (from i in projeContext.Trainings.Where(x => x.TrainingName != null).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TrainingName,
                                               Value = i.TrainingId.ToString()
                                           }).ToList();
            ViewBag.Lessons = lesson;
            List<Class> sınıflar = projeContext.Classes.ToList();
            List<Class> sınıflar3 = projeContext.Classes.Include(x => x.Training).ToList();
            List<Class> sınıflar2 = projeContext.Classes.Include(x => x.TrainingProgram).ToList();
            List<Class> sınıflar1 = new List<Class>();
            foreach (var t in trainingPrograms)
            {
                foreach (var s in sınıflar)
                {
                    if (t.TrainingProgramId == s.TrainingProgramId)
                    {
                        sınıflar1.Add(s);
                    }
                }
            }
            return View(sınıflar1);
        }
        [HttpGet]
        public ActionResult Update(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == sınıf.TrainingProgramId).FirstOrDefault();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == trainingProgram.TrainingId).FirstOrDefault();
            ClassTrainingProgram güncelle = new ClassTrainingProgram();
            ViewBag.Name = trainingProgram.Name;
            güncelle.ClassName = sınıf.ClassName;
            güncelle.ClassId = sınıf.ClassId;
            güncelle.TrainingName = training.TrainingName;
            güncelle.Kota = sınıf.Kota;
            return View(sınıf);
        }

        [HttpPost]
        public ActionResult Update(ClassDto classDto)
        {

            Proje2Context projeContext = new Proje2Context();
            if(classDto.Name == 0)
            {
                return Json("1");
            }
            if (classDto.Kota > 100)
            {
                return Json("17");
            }
            List<Class> sınıflar = projeContext.Classes.Where(x => x.ClassName == classDto.ClassName).ToList();
            foreach (var s in sınıflar)
            {
                TrainingProgram trainingProgram1 = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == s.TrainingProgramId).FirstOrDefault();
                if(trainingProgram1.Name == classDto.Name)
                {
                    return Json("50");
                }
            }
            Training training1 = projeContext.Trainings.Where(x => x.TrainingId == classDto.TrainingId).FirstOrDefault();
            if (classDto.Kota > training1.kota)
            {
                return Json("3");
            }
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == classDto.ClassId).FirstOrDefault();
            TrainingProgram trainingProgram = projeContext.TrainingPrograms.Where(x => x.TrainingProgramId == sınıf.TrainingProgramId).FirstOrDefault();
            
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == classDto.TrainingProgramId).FirstOrDefault();
            if(trainingProgramDetail != null )
            {
                return Json("9");
            }
            Training training = projeContext.Trainings.Where(x => x.TrainingId == classDto.TrainingId).FirstOrDefault();
             
            projeContext.Update(sınıf);
            int sonuc = projeContext.SaveChanges();
            _trainingProgramService.Update(trainingProgram);
            return Json("200");
        }


        [HttpGet]
        public ActionResult Delete(int TrainingProgramId)
        {
            Proje2Context projeContext = new Proje2Context();
            TrainingProgram trainingPrograms = projeContext.TrainingPrograms.Include(x => x.Training).Where(x => x.TrainingProgramId == TrainingProgramId).FirstOrDefault();
            Training training = projeContext.Trainings.Where(x => x.TrainingId == trainingPrograms.TrainingId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.TrainingProgramId == TrainingProgramId).FirstOrDefault();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == trainingPrograms.TrainingProgramId).ToList();
            User user = projeContext.Users.Where(x => x.ClassId == sınıf.ClassId).FirstOrDefault();
            Exam exam = projeContext.Exams.Where(x => x.ClassId == sınıf.ClassId).FirstOrDefault();
            if(exam != null)
            {
                return Json("3");
            }
            if(user != null)
            {
                return Json("2");
            }
            foreach (var t in trainingProgramDetails)
            {
                if ( t != null)
                {
                    return Json("1");
                }
            }
            if (sınıf != null)
            {
                projeContext.Remove(sınıf);
                int sonuc = projeContext.SaveChanges();
            }
            _trainingProgramService.Delete(TrainingProgramId);
            return Json("200");
        }

    }
}
