using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
      
        public IActionResult Register()
        {
            //if (User.Identity.IsAuthenticated) return RedirectToAction(nameof(HomeController.Index), "Home");
            return View();
        }

        [HttpPost/*, AllowAnonymous*/]
        public async Task<IActionResult> Register(/*RegisterDTO registerDTO*/ string p)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = await _userServeice.Register(registerDTO);

            //    if (result.Succeeded) return RedirectToAction("Index", "Home");

            //    foreach (var item in result.Errors) ModelState.AddModelError(string.Empty, item.Description);
            //}

            //return View(registerDTO);
            return View();
        }
      

    }
}
