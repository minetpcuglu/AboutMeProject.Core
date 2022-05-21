using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
     [Authorize(Roles="Admin")]
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

        [HttpPost]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            if (id != 0)
            {
                var result = await _educationService.DeleteAsync(id);
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
                //return RedirectToAction("GetList");

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateEducation(int id)
        {
            var value = await _educationService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEducation(EducationDTO educationDTO)
        {


            var validateResult = _educationValidator.Validate(educationDTO);
            if (validateResult.IsValid)
            {
                await _educationService.Update(educationDTO);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(educationDTO);

        }

    }
}
