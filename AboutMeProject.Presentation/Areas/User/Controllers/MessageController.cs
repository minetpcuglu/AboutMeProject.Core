using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Message")]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageUserService _messageuserService;

        public MessageController(ApplicationDbContext context, UserManager<AppUser> userManager, IMessageUserService messageuserService)
        {
            _context = context;
            _userManager = userManager;
            _messageuserService = messageuserService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("")]
        [Route("InBox")]
        public async Task<IActionResult> InBox(string user) //kullanıcıya ait gelen mesaj 
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user = valueUser.Email;
            var messageList = await _messageuserService.GetListReceiverMessage(user);
            return View(messageList);
        }
        [Route("")]
        [Route("SendBox")]
        public async Task<IActionResult> SendBox(string user) //kullanıcıya ait giden mesaj 
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            user = valueUser.Email;
            var messageList = await _messageuserService.GetListSenderMessage(user);
            return View(messageList);
        }

        [HttpGet]
        [Route("SendBoxMessageDetail/{id}")]
        public async Task<IActionResult> SendBoxMessageDetail(int id)
        {
            var value = await _messageuserService.GetById(id);
            return View(value);
        }

        [HttpGet]
        [Route("InBoxMessageDetail/{id}")]
        public async Task<IActionResult> InBoxMessageDetail(int id)
        {
            var value = await _messageuserService.GetById(id);
            return View(value);
        }

        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(MessageUserDTO messageUser)
        {
            var valueUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valueUser.Email;
            string name = valueUser.Name + " " + valueUser.Surname;
            messageUser.SenderMail = mail;
            messageUser.SenderName = name;
            //var namesurname = _context.Users.Where(x => x.Email == messageUser.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            //messageUser.ReceiverName = namesurname;
            await _messageuserService.Add(messageUser);
            return RedirectToAction("SendBox");
        }
    }
}
