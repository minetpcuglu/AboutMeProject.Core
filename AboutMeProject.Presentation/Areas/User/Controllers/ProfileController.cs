using AboutMeProject.Application.Extensions;
using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager; //siteme authentice olma
        private readonly IAppUserService _appUser;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserService appUser)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUser = appUser;
        }

        public async Task<IActionResult> EditProfile(int id)
        {
           
            if (id!=0)
            {
                var user = await _appUser.GetById(id);
                if (user == null) return NotFound();
                return View(user);
            }
            //else return RedirectToAction(nameof(HomeController.Index), "Home");
            //if (id != 0)
            //{
            //    var user = await _appUser.GetById(id);
            //    if (user == null) return NotFound();
            //    return View(user);
            //}
            else return RedirectToAction(nameof(DashboardController.Index), "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model, IFormFile file)
        {
            //model.Image = file;
            await _appUser.EditUser(model);
            return  RedirectToAction(nameof(DefaultController.Index), "Default");
        }

        //public IActionResult EditProfile(string p)
        //{
        //    return View();
        //}
    }
}
