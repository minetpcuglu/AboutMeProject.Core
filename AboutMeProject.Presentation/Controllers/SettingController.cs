using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IValidator<ServiceDTO> _settingValidator;

        public SettingController(ISettingService settingService, IValidator<ServiceDTO> settingValidator)
        {
            _settingService = settingService;
            _settingValidator = settingValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetList()
        {
            var value = await _settingService.GetAll();
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSetting(int id)
        {
            var value = await _settingService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSetting(ServiceDTO serviceDTO)
        {
            var validateResult = _settingValidator.Validate(serviceDTO);
            if (validateResult.IsValid)
            {
                await _settingService.Update(serviceDTO);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(serviceDTO);

        }
    }
}
