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
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IValidator<AboutDTO> _aboutValidator;

        public AboutController(IAboutService aboutService, IValidator<AboutDTO> aboutValidator)
        {
            _aboutService = aboutService;
            _aboutValidator = aboutValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _aboutService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutDTO aboutDTO)
        {
            var validateResult = _aboutValidator.Validate(aboutDTO);
            if (validateResult.IsValid)
            {
                await _aboutService.Update(aboutDTO);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(aboutDTO);

        }
    }
}
