using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.User
{
    public class SidebarUserId:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager; //siteme authentice olma
        private readonly IAppUserService _appUser;

        public SidebarUserId(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserService appUser)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUser = appUser;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserId = value.Id;
            return View();
        }
    }
}
