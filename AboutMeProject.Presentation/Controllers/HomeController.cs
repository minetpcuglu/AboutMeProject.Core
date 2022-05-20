using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMessageUserService _messageService;

        public HomeController(ILogger<HomeController> logger, IMessageUserService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        public async Task< IActionResult> Index()
        {
            string p = "Admin@gmail.com";
            var value = await _messageService.Take5List(p);

            return View(value);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
