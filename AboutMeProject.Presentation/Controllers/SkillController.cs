using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
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
        //private readonly IValidator<EducationVM> _educationValidator;
        public SkillController(ISkillService skillService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
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
            var addSkill = _skillService.Add(skill);
            return RedirectToAction("GetList");
        }
    }
}
