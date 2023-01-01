using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
    public class TitleController : Controller
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        } 

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Title title)
        {
            title.TitleId = 0;
            Proje2Context projeContext = new Proje2Context();

            TitleValidator titleValidator = new TitleValidator();
            ValidationResult results = titleValidator.Validate(title);
            if (!results.IsValid)
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;
                }
                return Json(message);
            }
            _titleService.Add(title);
            return Json("200");

        }

        public ActionResult GetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<Title> titles = projeContext.Titles.ToList();
            return View(titles); 
        }

        [HttpGet]
        public ActionResult Update(int TitleId)
        {
            Proje2Context projeContext = new Proje2Context();
            var result = _titleService.GetById(TitleId);
            ViewBag.UnvanAdı = result.TitleName;
            ViewBag.Title = TitleId; 
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Title model)
        {
            Proje2Context projeContext = new Proje2Context();


            TitleValidator titleValidator = new TitleValidator();
            ValidationResult results = titleValidator.Validate(model);
            if (!results.IsValid)
            {
                string message = "";
                foreach (var item in results.Errors)
                {
                    message += item.ErrorMessage;

                }
                return Json(message);
            }
            _titleService.Update(model);
            List<Educator> educators = projeContext.Educators.Where(x => x.TitleId == model.TitleId).ToList();
            foreach (var e in educators)
            {
                projeContext.Update(e);
                int sonuc = projeContext.SaveChanges();
            }
            return Json("200");
        }

        [HttpGet]
        public ActionResult Delete(int TitleId)
        {
            Proje2Context projeContext = new Proje2Context();
            Title title = projeContext.Titles.Where(x => x.TitleId == TitleId).FirstOrDefault();
            _titleService.Delete(TitleId);
            return Json("200");
        }


    }
}
