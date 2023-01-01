using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProjeMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddSingleton<IManagerService, ManagerManager>();
            services.AddSingleton<IManagerDal, EfManagerDal>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<ITrainingService, TrainingManager>();
            services.AddSingleton<ITrainingDal, EfTrainingDal>();
            services.AddSingleton<IWaitingService, WaitingManager>();
            services.AddSingleton<IWaitingDal, EfWaitingDal>();
            services.AddSingleton<IEducatorService, EducatorManager>();
            services.AddSingleton<IEducatorDal, EfEducatorDal>();
            services.AddSingleton<IExamService, ExamManager>();
            services.AddSingleton<IExamDal, EfExamDal>();
            services.AddSingleton<ITrainingProgramService, TrainingProgramManager>();
            services.AddSingleton<ITrainingProgramDal, EfTrainingProgramDal>();
            services.AddSingleton<ITrainingProgramDetailService, TrainingProgramDetailManager>();
            services.AddSingleton<ITrainingProgramDetailDal, EfTrainingProgramDetailDal>();
            services.AddSingleton<ITitleService, TitleManager>();
            services.AddSingleton<ITitleDal, EfTitleDal>();
            services.AddSingleton<IClassService, ClassManager>();
            services.AddSingleton<IClassDal, EfClassDal>();
            services.AddSingleton<ILessonService, LessonManager>();
            services.AddSingleton<ILessonDal, EfLessonDal>();
            services.AddSingleton<ICertificateService, CertificateManager>();
            services.AddSingleton<ICertificateDal, EfCertificateDal>();
            services.AddSingleton<IAttendanceService, AttendanceManager>();
            services.AddSingleton<IAttendanceDal, EfAttendanceDal>();

            services.AddSession(option =>
            {
                //Süre 1 dk olarak belirlendi
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/User/Login";
            //    options.LogoutPath = "/User/Logout";
            //    options.AccessDeniedPath = "/User/Denied";
            //    options.Cookie.Name = "Education.Cookie";
            //    options.SlidingExpiration = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=_SideBar}/{id?}");
                    pattern: "{controller=User}/{action=Login}/{id?}");
        });
        }
    }
}
