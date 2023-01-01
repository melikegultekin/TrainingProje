using Business.ValidationRules;
using Core.Utilities.Security.Hashing;
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
    public class AdminController : Controller
    {
        Proje2Context projeContext = new Proje2Context();

        public IActionResult Educator()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Educator> educators = projeContext.Educators.Include(x => x.Title).ToList();
            List<Title> titles = projeContext.Titles.ToList();
            List<SelectListItem> unvan = (from i in projeContext.Titles.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TitleName,
                                               Value = i.TitleId.ToString()
                                           }).ToList();
            ViewBag.Unvan = unvan;
            return View(educators);
        }

        public IActionResult User()
        {
            Proje2Context projeContext = new Proje2Context();
            List<User> users = projeContext.Users.Include(x => x.Class).Where(x => x.ClassId != null).ToList();

            return View(users);
        }
        
        public IActionResult Training()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Lesson> lessons = projeContext.Lessons.Include(x => x.Training).ToList();
            List<Training> trainings = projeContext.Trainings.ToList();
            return View(trainings);

        }

        public IActionResult TrainingProgramGetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<TrainingProgram> trainingPrograms = projeContext.TrainingPrograms.Include(x => x.Training).Where(x => x.Name == 1).ToList();

            List<SelectListItem> lesson = (from i in projeContext.Trainings.Where(x => x.TrainingName != null && x.TrainingLastdate > DateTime.Now).ToList()
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


        public IActionResult Profile(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            Educator educator = projeContext.Educators.Include(x=>x.Title).Where(x => x.EducatorId == EducatorId).FirstOrDefault();
            Title title = projeContext.Titles.Where(x => x.TitleId == educator.TitleId).FirstOrDefault();
            ViewBag.TitleName = title.TitleName;
            return View(educator);
        }
    }
}
