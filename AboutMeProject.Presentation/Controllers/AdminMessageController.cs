using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IMessageUserService _messageuserService;

        public AdminMessageController(IMessageUserService messageuserService)
        {
            _messageuserService = messageuserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AdminSendbox()
        {
            string p;
            p = "admin@gmail.com";
            var value = await _messageuserService.GetListSenderMessage(p);
            return View(value);

        }
        public async Task<IActionResult> AdminReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var value = await _messageuserService.GetListReceiverMessage(p);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> AdminMessageDetail(int id)
        {
            var value = await _messageuserService.GetById(id);
            return View(value);
        }


    }
}
