using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserMessageService _usermessageService;

        public MessageController(IUserMessageService usermessageService)
        {
            _usermessageService = usermessageService;
        }

        public IActionResult Index()
        {
            var value = _usermessageService.GetAll();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var value = await _usermessageService.GetByIdUserMessage(id);
            return View(value);
        }
    }
}
