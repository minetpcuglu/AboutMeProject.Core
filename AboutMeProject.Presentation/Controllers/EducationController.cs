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
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IValidator<EducationDTO> _educationValidator;

        public EducationController(IEducationService educationService, IValidator<EducationDTO> educationValidator)
        {
            _educationService = educationService;
            _educationValidator = educationValidator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetList()
        {
            var value = await _educationService.GetAll();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEducation(EducationDTO education)
        {
            var validateResult = _educationValidator.Validate(education);
            if (validateResult.IsValid)
            {
                await _educationService.Add(education);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(education);

        }
    }
}
