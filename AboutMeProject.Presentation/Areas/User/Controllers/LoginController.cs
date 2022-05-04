using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    []
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
    }
}
