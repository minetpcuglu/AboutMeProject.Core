﻿using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ISettingService _settingService;
        //private readonly IValidator<EducationVM> _educationValidator;
     
        public DefaultController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            var value = await _settingService.GetAll();
            return View(value);
        }
    }
}