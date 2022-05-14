using AboutMeProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.User
{
    public class NavbarUserProfileImage : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
       

        public NavbarUserProfileImage(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Image = value.ImageUrl;

            var valueId = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserId = value.Id;

            return View();
        }
    }
}
