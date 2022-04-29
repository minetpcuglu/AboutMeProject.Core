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
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IValidator<SkillDTO> _skillValidator;
        public SkillController(ISkillService skillService, IValidator<SkillDTO> skillValidator)
        {
            _skillValidator = skillValidator;
            _skillService = skillService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async  Task<IActionResult> GetList()
        {
            var value = await _skillService.GetAll();
            
            return View(value);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillDTO skill)
        {
            var validateResult = _skillValidator.Validate(skill);
            if (validateResult.IsValid)
            {
                await _skillService.Add(skill);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(skill);
       
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (id != 0)
            {
                var result = await _skillService.DeleteAsync(id);
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
    }
}
