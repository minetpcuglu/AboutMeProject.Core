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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //uygulamaya geliþtirdiðimiz context nesnesi DbContext olarak tanýtýlmaktadýr.
            #endregion

            #region Identity ValidatorRules
            services.AddIdentity<AppUser, AppRole>
               (x =>
               {
                   x.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluðunu kaldýrýyoruz.
                   x.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrýyoruz.
                   x.Password.RequireUppercase = false; //Büyük harf zorunluluðunu kaldýrýyoruz.
                   x.Password.RequireDigit = false; //0-9 arasý sayýsal karakter zorunluluðu 
                   x.User.RequireUniqueEmail = false; //Email adreslerini tekilleþtiriyoruz.

                   //x.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+"; //Kullanýcý adýnda geçerli olan karakterleri belirtiyoruz.

               }).AddPasswordValidator<CustomPasswordValidation>()
         .AddUserValidator<CustomUserValidation>()
         .AddErrorDescriber<CustomIdentityErrorDescriber>()
         .AddEntityFrameworkStores<ApplicationDbContext>();//(þifremi unuttum!)  //identity yapýlanmasýna dair gerekli entegrasyonu “AddIdentity” metodu ile gerçekleþtirmekteyiz.

            //böylece hem password hemde user temelli custom validasyon yapýlanmasý saðlanmýþ bulunmaktadýr.
            #endregion


            #region IoC
            services.AddScoped<IAboutService, AboutService>(); /// dý 
            services.AddScoped<IAnnouncementService, AnnouncementService>(); /// dý 
            services.AddScoped<IAppUserService, AppUserService>(); /// dý 
            services.AddScoped<IToDoListService, ToDoListService>(); /// dý 
            services.AddScoped<IFeatureService, FeatureService>(); /// dý 
            services.AddScoped<ISettingService, SettingService>(); /// dý 
            services.AddScoped<ISkillService, SkillService>(); /// dý 
            services.AddScoped<IContactService, ContactService>(); /// dý 
            services.AddScoped<IPortfolioService, PortfolioService>(); /// dý 
            services.AddScoped<IEducationService, EducationService>(); /// dý 
            services.AddScoped<IUserMessageService, UserMessageService>(); /// dý 
            services.AddScoped<IMessageService, MessageService>(); /// dý 
            services.AddScoped<IMessageUserService, MessageUserService>(); /// dý 
            services.AddScoped<IUserService, UserService>(); /// dý 

            #endregion
            #region Automapper
            services.AddAutoMapper(typeof(AboutMapping));
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
            services.AddSingleton<IValidator<SkillDTO>, SkillValidation>(); // constructor injection kullanacaðýmýz için Validator sýnýfýmýzý ve servisimizi inject ediyoruz. 
            services.AddSingleton<IValidator<EducationDTO>, EducationValidation>();
            services.AddSingleton<IValidator<PortfolioDTO>, PortfolioValidation>();
            services.AddSingleton<IValidator<FeatureDTO>, FeatureValidation>();
            services.AddSingleton<IValidator<AboutDTO>, AboutValidation>();
            services.AddSingleton<IValidator<ServiceDTO>, SettingValidation>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();  //identity
            app.UseAuthorization();   //IoC

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
