using AboutMeProject.Application.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Areas.User.ViewComponents
{
    public class Notification:ViewComponent
    {
       private readonly AnnouncementService _announcementService;

        public Notification(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var value = await _announcementService.Take5List();
            return View(/*value*/);
        }
    }
}
