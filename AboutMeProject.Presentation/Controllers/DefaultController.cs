using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        public async Task<IActionResult> CreateContact(MessageDTO messageDTO)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");
            messageDTO.Date = DateTime.Now.ToShortDateString();
            await _messageService.Add(messageDTO);
            return this.Ok($"Form Data received!");
        }
    }
}
