using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    //[AllowAnonymous]
    [Area("User")]
    [Route("User/[controller]/[action]")]
    //[Authorize]
    public class DefaultController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public DefaultController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<IActionResult> Index()
        {
            
            var value = await _announcementService.GetAll();
            return View(value);
        }
    }
}
