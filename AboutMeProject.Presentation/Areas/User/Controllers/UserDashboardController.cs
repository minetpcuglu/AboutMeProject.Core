using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class UserDashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserMessageService _messageService;
        private readonly   IAnnouncementService  _announcemenntService;
        private readonly   IAppUserService  _appUserService;
        private readonly   ISkillService  _skillService;

        public UserDashboardController(UserManager<AppUser> userManager, IUserMessageService messageService, IAnnouncementService announcemenntService, IAppUserService appUserService, ISkillService skillService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _announcemenntService = announcemenntService;
            _appUserService = appUserService;
            _skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = value.Name + " " + value.Surname;
            ViewBag.User = value.UserName;

            var valueAnnouncemennt = await _announcemenntService.GetTotelAnnouncoment();
            ViewBag.NotificationCount = valueAnnouncemennt;

            var valueAppUser = await _appUserService.GetTotelUser();
            ViewBag.UserCount = valueAppUser;

            var valueSkill = await _skillService.GetTotelSkill();
            ViewBag.AbilityCount = valueSkill;

            return View();
        }
    }
}
