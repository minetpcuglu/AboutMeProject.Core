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
        //private readonly UserManager<>
        public IActionResult EditProfile()
        {
            return View();
        }

        //public IActionResult EditProfile(string p)
        //{
        //    return View();
        //}
    }
}
