using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageUserService _messageuserService;

        public MessageController(UserManager<AppUser> userManager, IMessageUserService messageuserService)
        {
            _userManager = userManager;
            _messageuserService = messageuserService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> InBox(string user) //kullanıcıya ait gelen mesaj 
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user = valueUser.Email;
            var messageList = await _messageuserService.GetListReceiverMessage(user);
            return View(messageList);
        }
        public async Task<IActionResult> SendBox(string user) //kullanıcıya ait gelen mesaj 
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user = valueUser.Email;
            var messageList = await _messageuserService.GetListSenderMessage(user);
            return View(messageList);
        }

        [HttpGet]
        public async Task<IActionResult> SendBoxMessageDetail(int id)
        {
            var value = await _messageuserService.GetById(id);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> InBoxMessageDetail(int id)
        {
            var value = await _messageuserService.GetById(id);
            return View(value);
        }

        public async Task<IActionResult> SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageUserDTO messageUser)
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valueUser.Email;
            string name = valueUser.Name;
            messageUser.SenderMail = mail;
            messageUser.SenderName = name;
            await _messageuserService.Add(messageUser);
            return RedirectToAction("SendBox","Message","User");
        }
    }
}
