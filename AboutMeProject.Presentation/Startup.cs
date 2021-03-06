using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Concrete;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Application.Utilities.AutoMapper;
using AboutMeProject.Application.Utilities.Validations.CustomValidation;
using AboutMeProject.Application.Utilities.Validations.FluentValidation;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Infrastructure.Context;
using AboutMeProject.Presentation.Controllers;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation
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

            #region context
            services.AddScoped<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //uygulamaya geliştirdiğimiz context nesnesi DbContext olarak tanıtılmaktadır.
            #endregion
            #region Identity ValidatorRules
            services.AddIdentity<AppUser, AppRole>
               (x =>
               {
                   x.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluğunu kaldırıyoruz.
                   x.Password.RequireLowercase = false; //Küçük harf zorunluluğunu kaldırıyoruz.
                   x.Password.RequireUppercase = false; //Büyük harf zorunluluğunu kaldırıyoruz.
                   x.Password.RequireDigit = false; //0-9 arası sayısal karakter zorunluluğu 
                   x.User.RequireUniqueEmail = false; //Email adreslerini tekilleştiriyoruz.

                   //x.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+"; //Kullanıcı adında geçerli olan karakterleri belirtiyoruz.

               }).AddPasswordValidator<CustomPasswordValidation>()
         .AddUserValidator<CustomUserValidation>()
         .AddErrorDescriber<CustomIdentityErrorDescriber>()
         .AddEntityFrameworkStores<ApplicationDbContext>();//(şifremi unuttum!)  //identity yapılanmasına dair gerekli entegrasyonu AddIdentity metodu ile gerçekleştirmekteyiz.

            //böylece hem password hemde user temelli custom validasyon yapılanması sağlanmış bulunmaktadır.
            #endregion
            #region IoC
            services.AddScoped<IAboutService, AboutService>(); /// dı 
            services.AddScoped<ISocialMediaService, SocialMediaService>(); /// dı 
            services.AddScoped<IAnnouncementService, AnnouncementService>(); /// dı 
            services.AddScoped<IAppUserService, AppUserService>(); /// dı 
            services.AddScoped<IToDoListService, ToDoListService>(); /// dı 
            services.AddScoped<IFeatureService, FeatureService>(); /// dı 
            services.AddScoped<ISettingService, SettingService>(); /// dı 
            services.AddScoped<ISkillService, SkillService>(); /// dı 
            services.AddScoped<IContactService, ContactService>(); /// dı 
            services.AddScoped<IPortfolioService, PortfolioService>(); /// dı 
            services.AddScoped<IEducationService, EducationService>(); /// dı 

            services.AddScoped<IMessageService, MessageService>(); /// dı 
            services.AddScoped<IMessageUserService, MessageUserService>(); /// dı 
     

            #endregion
            #region Automapper
            services.AddAutoMapper(typeof(AboutMapping));
            services.AddAutoMapper(typeof(SocialMediaMapping));
            services.AddAutoMapper(typeof(FeatureMapping));
            services.AddAutoMapper(typeof(ToDoListMapping));
            services.AddAutoMapper(typeof(SettingMapping));
            services.AddAutoMapper(typeof(SkillMapping));
            services.AddAutoMapper(typeof(ContactMapping));
            services.AddAutoMapper(typeof(PortfolioMapping));
            services.AddAutoMapper(typeof(EducationMapping));
            services.AddAutoMapper(typeof(MessageMapping));
            services.AddAutoMapper(typeof(MessageUserMapping));
            services.AddAutoMapper(typeof(AppUserMapping));
            services.AddAutoMapper(typeof(AnnouncementMapping));
            #endregion
            #region FluentValidation
            services.AddSingleton<IValidator<SkillDTO>, SkillValidation>(); // constructor injection kullanacağımız için Validator sınıfımızı ve servisimizi inject ediyoruz. 
            services.AddSingleton<IValidator<EducationDTO>, EducationValidation>();
            services.AddSingleton<IValidator<PortfolioDTO>, PortfolioValidation>();
            services.AddSingleton<IValidator<FeatureDTO>, FeatureValidation>();
            services.AddSingleton<IValidator<AboutDTO>, AboutValidation>();
            services.AddSingleton<IValidator<ServiceDTO>, SettingValidation>();
            #endregion
            #region Authorize
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy)); //proje seviyesinde authorize yetkilendirme işlemi
            });
            services.ConfigureApplicationCookie(options =>
            {

                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/User/Login/UserLogin/";
                options.AccessDeniedPath = "/ErrorPage/Error401/";
            });
            #endregion


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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/"); //hata sayfası
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();  //identity
            app.UseAuthorization();   //IoC

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
                );
            });

          

        }
    }
}
