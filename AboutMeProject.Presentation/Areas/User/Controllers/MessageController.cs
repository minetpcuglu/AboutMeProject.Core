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
            var messageList = await _messageuserService.GetAllFilter(user);
            return View(messageList);
        }
    }
}
