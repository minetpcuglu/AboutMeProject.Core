using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Setting
{
    public class SettingList : ViewComponent
    {
        private readonly ISettingService _settingService;
        //private readonly IValidator<EducationVM> _educationValidator;
        public SettingList(ISettingService settingService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
            _settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var value = await _settingService.GetAll();
            return View(value);
        }
    }
}
