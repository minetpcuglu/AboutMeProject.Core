using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Education
{
    public class EducationList : ViewComponent
    {
        private readonly IEducationService _educationService;
        //private readonly IValidator<EducationVM> _educationValidator;
        public EducationList(IEducationService educationService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
            _educationService = educationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _educationService.GetAll();
            return View(value);
        }
    }
}
