using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AutoMapper;
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
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        readonly SignInManager<AppUser> _signInManager; //siteme authentice olma

        private readonly IAppUserService _appUser;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper, IAppUserService appUser, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appUser = appUser;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]

        public IActionResult RegisterUser()
        {
            //if (User.Identity.IsAuthenticated) return RedirectToAction(nameof(HomeController.Index), "Home");
            return View();
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<IActionResult> RegisterUser(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var appUser = _mapper.Map<RegisterViewModel, AppUser>(registerVM);
                //AppUser appUser = new AppUser
                //{
                //    UserName = appUserViewModel.UserName,
                //    Email = appUserViewModel.Email
                //};
                IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password); //identity kendi kütüphanesi create
                if (result.Succeeded)
                    return RedirectToAction("UserLogin","Login");
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));

            }
            return View();
        }


    }
}
