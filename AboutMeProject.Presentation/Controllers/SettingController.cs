using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Models.VMs;
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
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceDTO service)
        {
            var validateResult = _settingValidator.Validate(service);
            if (validateResult.IsValid)
            {
                await _settingService.Add(service);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(service);

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
        [HttpPost]
        public async Task<IActionResult> DeleteSetting(int id)
        {
            if (id != 0)
            {
                var result = await _settingService.DeleteAsync(id);
                if (result)
                {
                    return Json(new ToastViewModel
                    {
                        Message = "Deleted.",
                        Success = true
                    });
                }
                else
                {
                    return Json(new ToastViewModel
                    {
                        Message = "Operation Failed.",
                        Success = false
                    });
                }
                

            }
            return View();

        }
    }
}
