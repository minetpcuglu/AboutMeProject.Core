using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Presentation.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class LoginController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly IAppUserService _appUser;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserService appUser)
        {
            _appUser = appUser;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserLogin(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","UserDashboard");
            }
            //kullanıcının yetkisinin olmadığı sayfalara erişmeye  çalıştığında  direkt olarak “Login” actionına yönlendirecektir
            ViewData["ReturnUrl"] = returnUrl; //temt data kontrolu atandi
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginViewModel loginView, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUser.Login(loginView);

                if (result.Succeeded) return RedirectToLocal(returnUrl);

                ModelState.AddModelError(String.Empty, "Invalid login attempt..!");
            }

            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
            else return RedirectToAction(nameof(UserDashboardController.Index), "UserDashboard");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _appUser.LogOut();
            return RedirectToAction(nameof(DashboardController.Index), "Dashboard");
        }
    }
}
