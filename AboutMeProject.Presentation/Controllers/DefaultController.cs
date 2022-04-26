using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
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
        private readonly IMessageService _messageService;
        //private readonly IValidator<EducationVM> _educationValidator;

        public DefaultController(ISettingService settingService, IMessageService messageService)
        {
            _messageService = messageService;
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

        [HttpGet]
        public async Task<PartialViewResult> Add()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<PartialViewResult> Add(MessageDTO messageDTO)
        {
            await _messageService.Add(messageDTO);
            return PartialView();

        }
    }
}
