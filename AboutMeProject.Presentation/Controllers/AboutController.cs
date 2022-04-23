using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        //private readonly IValidator<EducationVM> _educationValidator;
        public AboutController(IAboutService aboutService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> GetList()
        {
            var value =  await _aboutService.GetAll();
            
            return View(value);
        }
    }
}
