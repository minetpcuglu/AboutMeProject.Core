using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Notification
{
    public class NotificationLast5:ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public NotificationLast5(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _announcementService.Take5List();
            return View(value);
        }
    }
}
