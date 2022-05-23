using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        private readonly IMessageUserService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public AdminNavbarMessageList(IMessageUserService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string p = "Admin@gmail.com";
            var value = await _messageService.Take5List(p);

            //var valueImage = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.Image = valueImage.ImageUrl;
            ViewBag.MessageCount = await  _messageService.GetTotelMessageCount(p);
            return View(value);
        }
    }
}
