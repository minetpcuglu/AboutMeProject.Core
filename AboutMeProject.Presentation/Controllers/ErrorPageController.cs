using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error401()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
