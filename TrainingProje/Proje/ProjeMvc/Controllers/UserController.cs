using Business.ValidationRules;
using Entities.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Business.Abstract;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjeMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;


        public IActionResult Index()
        {
            return View();
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            Proje2Context projeContext = new Proje2Context();
            User userToCheck = projeContext.Users.Where(x => x.UserName == userForLoginDto.UserName).FirstOrDefault();


            if (userToCheck == null)
            {
                TempData["ErrorMessage"] = "Hatalı kullanıcı...!";
                return View();
            }

            if (userToCheck.Role == 1)
            {
                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    TempData["ErrorMessage"] = "Hatalı şifre...!";
                    return View();
                }
                HttpContext.Session.SetString("UserName", userForLoginDto.UserName);
                TempData["AlertMessage"] = "Giriş işleminiz başarılı...!";
                return RedirectToAction(actionName: "Educator", controllerName: "Admin");
            }

            if (userToCheck.Role == 0)

                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    TempData["ErrorMessage"] = "Hatalı şifre...!";
                    //return RedirectToAction(actionName: "UserVar", controllerName: "User");
                    return View();
                }
            HttpContext.Session.SetString("UserName", userForLoginDto.UserName);
            TempData["AlertMessage"] = "Giriş işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Training");

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            Proje2Context projeContext = new Proje2Context();
            bool userExists = !(projeContext.Users.Where(x => x.UserName == userForRegisterDto.UserName).FirstOrDefault() == null);
            if (userExists)
            {

                TempData["ErrorMessage"] = "Girdiğiniz kullanıcı mevcut lütfen başka kullanıcı ismi giriniz!...";
                return View();
            }
            UserRegisterValidator userregisterValidator = new UserRegisterValidator();
            ValidationResult results = userregisterValidator.Validate(userForRegisterDto);
            if (results.IsValid)
            {
                _userService.Register(userForRegisterDto, userForRegisterDto.Password, userForRegisterDto.Passwordtekrar);
            }
            else
            {

                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            HttpContext.Session.SetString("UserName", userForRegisterDto.UserName);

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            projeContext.Users.Add(new User() { UserName = userForRegisterDto.UserName, FirstName = userForRegisterDto.FirstName, LastName = userForRegisterDto.LastName, Email = userForRegisterDto.Email, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Tc = userForRegisterDto.Tc,  Role = 0 });
            TempData["AlertMessage"] = "Kullanıcı Kayıt işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Training");


        }

        [HttpGet]
        public IActionResult RegisterM()
        {
            return View();
        }

        [HttpPost("RegisterM")]
        public IActionResult RegisterM(UserForRegisterDto userForRegisterDto)
        {
            Proje2Context projeContext = new Proje2Context();
            bool userExists = !(projeContext.Users.Where(x => x.UserName == userForRegisterDto.UserName).FirstOrDefault() == null);
            if (userExists)
            {

                TempData["ErrorMessage"] = "Girdiğiniz kullanıcı mevcut lütfen başka kullanıcı ismi giriniz!...";
                return View();
            }
            UserRegisterValidator userregisterValidator = new UserRegisterValidator();
            ValidationResult results = userregisterValidator.Validate(userForRegisterDto);
            if (results.IsValid)
            {
                _userService.RegisterM(userForRegisterDto, userForRegisterDto.Password, userForRegisterDto.Passwordtekrar);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            HttpContext.Session.SetString("UserName", userForRegisterDto.UserName);

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            projeContext.Users.Add(new User() { UserName = userForRegisterDto.UserName, FirstName = userForRegisterDto.FirstName, LastName = userForRegisterDto.LastName, Email = userForRegisterDto.Email, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Tc = userForRegisterDto.Tc, Role = 1 });
            TempData["AlertMessage"] = "kayıt işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAll", controllerName: "Manager");

        }



        public ActionResult GetAll()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName");
            Proje2Context projeContext = new Proje2Context(); 
            List<Training> trainings = projeContext.Trainings.ToList();
            return View(trainings);
        }

        public ActionResult YGetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<User> yetkili = projeContext.Users.Where(x => x.Role == 1).ToList();
            return View(yetkili);
        }

        public ActionResult UGetAll()
        {
            Proje2Context projeContext = new Proje2Context();
            List<User> uye = projeContext.Users.Where(x => x.Role == 0).ToList();
            return View(uye);
        }

        [HttpGet]
        public IActionResult Authorized()
        {
            Proje2Context projeContext = new Proje2Context();
            //List<Educator> educators = projeContext.Educators.ToList();
            List<SelectListItem> educator = (from i in projeContext.Educators.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.EducatorFullName,
                                                     Value = i.EducatorId.ToString()
                                                 }).ToList();
            ViewBag.Educators = educator;

            //List<SelectListItem> training = (from i in projeContext.Trainings.Where(x=>x.EducatorFullName == HttpContext.Session.GetString("EducatorFullName")).ToList()
            List<SelectListItem> training = (from i in projeContext.Trainings.ToList()
                                             select new SelectListItem
                                             {
                                                 //Text = i.TrainingName,
                                                 Value = i.TrainingId.ToString()
                                             }).ToList();
            ViewBag.Trainings = training;
            
            return View();
        }

        [HttpPost]
        public IActionResult Authorized(TrainingProgram model)
        {
            model.TrainingProgramId = 0;
            Proje2Context projeContext = new Proje2Context();
            TrainingProgram trainingProgram = new TrainingProgram();
            projeContext.TrainingPrograms.Add(model);
            int sonuc = projeContext.SaveChanges();
            TempData["AlertMessage"] = "Ekleme işleminiz başarılı...!";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            ViewBag.username = HttpContext.Session.GetString("Username");
            HttpContext.Session.Remove("Username");
            //return View();
            TempData["AlertMessage"] = "Çıkış Yaptınız...!";
            //return RedirectToAction("Login");
            return Redirect("https://localhost:5001/");
        }
        [HttpGet]
        public IActionResult BosAlan()
        {
            return View();
        }

        public ActionResult GetTraining(int EducatorId)
        {
            Proje2Context projeContext = new Proje2Context();
            return View();
        }


        public JsonResult GetTrainingPrograms(int educatorId) 
        {
            Proje2Context projeContext = new Proje2Context();
            var model = projeContext.TrainingProgramDetail.Where(x => x.EducatorId == educatorId).ToList();
            return Json(model);
        }

        [HttpGet]
        public ActionResult Program(int UserId)
        {
            Proje2Context projeContext = new Proje2Context();
            User user = projeContext.Users.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            TrainingProgramDetail trainingProgramDetail1 = new TrainingProgramDetail();

            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = user.LastName;

            if (user.ClassId == null) {

                return View(trainingProgramDetail1);
            }
            if(sınıf.TrainingProgramId == null)
            {
                return View(trainingProgramDetail1);
            }
            TrainingProgramDetail trainingProgramDetail = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == sınıf.TrainingProgramId).FirstOrDefault();
            
            ViewBag.ClassId = sınıf.ClassId;
            ViewBag.ClassName = sınıf.ClassName;

            List<Lesson> lesson1 = projeContext.Lessons.Include(x => x.Training).ToList();
            List<SelectListItem> educator = (from i in projeContext.Educators.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.EducatorFullName,
                                                 Value = i.EducatorId.ToString()
                                             }).ToList();
            ViewBag.Educators = educator;

            Lesson lesson = projeContext.Lessons.Where(x => x.TrainingId != null).FirstOrDefault();

            List<SelectListItem> training = (from i in projeContext.Lessons.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.LessonName,
                                                 Value = i.LessonId.ToString()
                                             }).ToList();
            ViewBag.Lessons = training;


            return View(trainingProgramDetail);
        }

        public JsonResult GetTrainingProgramsByClass(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            if(sınıf == null)
            {
                return Json("9");
            }
            Class sınıf1 = projeContext.Classes.Where(x => x.ClassId == sınıf.ClassId).FirstOrDefault();
            List<TrainingProgramDetail> trainingProgramDetails = projeContext.TrainingProgramDetail.Where(x => x.TrainingProgramId == sınıf1.TrainingProgramId).ToList();
            return Json(trainingProgramDetails);
        }

        [HttpGet]
        public ActionResult UserProg(UserProgDto model)
        {
            Proje2Context projeContext = new Proje2Context();
            Waiting waiting = projeContext.Waiting.Where(x => x.WaitingId == model.WaitingId).FirstOrDefault();
            User user = projeContext.Users.Where(x => x.UserId == waiting.UserId && x.ClassId == null).FirstOrDefault();
            
            user.ClassId = model.ClassId;
            projeContext.Update(user);
            int sonuc1 = projeContext.SaveChanges();
            //_userService.Update(user);
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            if(sınıf.Kota != 0)
            {
                sınıf.Kota--;
            }
            projeContext.Update(sınıf);
            int sonuc = projeContext.SaveChanges();
            return Json("200");
        }

        [HttpGet]
        public ActionResult SListesi(int ClassId)
        {
            Proje2Context projeContext = new Proje2Context();

            List<User> users = projeContext.Users.Where(x => x.ClassId == ClassId).ToList();
            return View(users);
        }

        [HttpPost]
        public ActionResult SListesi()
        {
            Proje2Context projeContext = new Proje2Context();
            return View();
        }

        public ActionResult GetAllU()
        {
            Proje2Context projeContext = new Proje2Context();
            List<User> users = projeContext.Users.Include(x=>x.Class).Where(x => x.ClassId != null).ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult UpdateS(int UserId)
        {
            Proje2Context projeContext = new Proje2Context();
            var result = _userService.GetById(UserId);
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == result.ClassId).FirstOrDefault();
            List<SelectListItem> sınıflar = (from i in projeContext.Classes.Where(x => x.TrainingId == sınıf.TrainingId).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.ClassName,
                                              Value = i.ClassId.ToString()
                                          }).ToList();
            ViewBag.Classes = sınıflar;
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateS(User model)
        {
            Proje2Context projeContext = new Proje2Context();
            User kullanıcı = projeContext.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
            Class sınıf1 = projeContext.Classes.Where(x => x.ClassId == kullanıcı.ClassId).FirstOrDefault();
            if(model.ClassId == null)
            {
                TempData["AlertMessage"] = "Bir sınıf seçiniz...!";
                return RedirectToAction(actionName: "GetAllU", controllerName: "User");
            }
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == model.ClassId).FirstOrDefault();
            if(sınıf.Kota == 0)
            {
                TempData["AlertMessage"] = "Seçilen sınıf için mevcut dolmuştur...!";
                return RedirectToAction(actionName: "GetAllU", controllerName: "User");
            }
            User user = projeContext.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
            user.ClassId = sınıf.ClassId;
            sınıf.Kota--;
            projeContext.Update(sınıf);
            int sonuc = projeContext.SaveChanges();
            _userService.Update(user);
            sınıf1.Kota++;
            projeContext.Update(sınıf1);
            int sonuc1 = projeContext.SaveChanges();
            TempData["AlertMessage"] = "Güncelleme işleminiz başarılı...!";
            return RedirectToAction(actionName: "GetAllU", controllerName: "User");
        }

        [HttpGet]
        public ActionResult Detailss(int UserId)
        {
            var result = _userService.GetById(UserId);
            ViewBag.Tc = result.Tc;
            ViewBag.UserName = result.UserName;
            ViewBag.FirstName = result.FirstName;
            ViewBag.LastName = result.LastName;
            ViewBag.Email = result.Email;
            return View();
        } 

        [HttpGet]
        public ActionResult DeleteS(int UserId)
        {
            //var result = _userService.GetById(UserId);
            Proje2Context projeContext = new Proje2Context();

            User user = projeContext.Users.Where(x => x.UserId == UserId).FirstOrDefault();
            Class sınıf = projeContext.Classes.Where(x => x.ClassId == user.ClassId).FirstOrDefault();
            sınıf.Kota++;
            user.ClassId = null;
            _userService.Update(user);
            projeContext.Update(sınıf);
            int sonuc = projeContext.SaveChanges();
            return Json("200");
        }

    }
}






