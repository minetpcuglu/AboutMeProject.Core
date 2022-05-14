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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //uygulamaya geli�tirdi�imiz context nesnesi DbContext olarak tan�t�lmaktad�r.
            #endregion

            #region Identity ValidatorRules
            services.AddIdentity<AppUser, AppRole>
               (x =>
               {
                   x.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
                   x.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
                   x.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
                   x.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�u 
                   x.User.RequireUniqueEmail = false; //Email adreslerini tekille�tiriyoruz.

                   //x.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+"; //Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.

               }).AddPasswordValidator<CustomPasswordValidation>()
         .AddUserValidator<CustomUserValidation>()
         .AddErrorDescriber<CustomIdentityErrorDescriber>()
         .AddEntityFrameworkStores<ApplicationDbContext>();//(�ifremi unuttum!)  //identity yap�lanmas�na dair gerekli entegrasyonu �AddIdentity� metodu ile ger�ekle�tirmekteyiz.

            //b�ylece hem password hemde user temelli custom validasyon yap�lanmas� sa�lanm�� bulunmaktad�r.
            #endregion


            #region IoC
            services.AddScoped<IAboutService, AboutService>(); /// d� 
            services.AddScoped<IAnnouncementService, AnnouncementService>(); /// d� 
            services.AddScoped<IAppUserService, AppUserService>(); /// d� 
            services.AddScoped<IToDoListService, ToDoListService>(); /// d� 
            services.AddScoped<IFeatureService, FeatureService>(); /// d� 
            services.AddScoped<ISettingService, SettingService>(); /// d� 
            services.AddScoped<ISkillService, SkillService>(); /// d� 
            services.AddScoped<IContactService, ContactService>(); /// d� 
            services.AddScoped<IPortfolioService, PortfolioService>(); /// d� 
            services.AddScoped<IEducationService, EducationService>(); /// d� 
            services.AddScoped<IUserMessageService, UserMessageService>(); /// d� 
            services.AddScoped<IMessageService, MessageService>(); /// d� 
            services.AddScoped<IMessageUserService, MessageUserService>(); /// d� 
            services.AddScoped<IUserService, UserService>(); /// d� 

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
            services.AddSingleton<IValidator<SkillDTO>, SkillValidation>(); // constructor injection kullanaca��m�z i�in Validator s�n�f�m�z� ve servisimizi inject ediyoruz. 
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
