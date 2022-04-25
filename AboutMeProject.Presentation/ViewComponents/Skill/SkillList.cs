using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        private readonly ISkillService _skillService;
        //private readonly IValidator<EducationVM> _educationValidator;
        public SkillList(ISkillService skillService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
            _skillService = skillService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var value = await _skillService.GetAll();
            return View(value);
        }
    }
}
