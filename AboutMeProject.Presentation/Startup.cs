using AboutMeProject.Application.Services.Concrete;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Application.Utilities.AutoMapper;
using AboutMeProject.Infrastructure.Context;
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
            services.AddTransient<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //uygulamaya geli�tirdi�imiz context nesnesi DbContext olarak tan�t�lmaktad�r.
            #endregion

            #region IoC
            services.AddScoped<IAboutService, AboutService>(); /// d� 
            services.AddScoped<IFeatureService, FeatureService>(); /// d� 
            services.AddScoped<ISettingService, SettingService>(); /// d� 
            services.AddScoped<ISkillService, SkillService>(); /// d� 
            services.AddScoped<IContactService, ContactService>(); /// d� 
            services.AddScoped<IPortfolioService, PortfolioService>(); /// d� 
            services.AddScoped<IEducationService, EducationService>(); /// d� 
            services.AddScoped<IMessageService, MessageService>(); /// d� 
         
            #endregion
            #region Automapper
            services.AddAutoMapper(typeof(AboutMapping));
            services.AddAutoMapper(typeof(FeatureMapping));
            services.AddAutoMapper(typeof(SettingMapping));
            services.AddAutoMapper(typeof(SkillMapping));
            services.AddAutoMapper(typeof(ContactMapping));
            services.AddAutoMapper(typeof(PortfolioMapping));
            services.AddAutoMapper(typeof(EducationMapping));
            services.AddAutoMapper(typeof(MessageMapping));
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
        }
    }
}
