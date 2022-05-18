using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaList(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var value = await _socialMediaService.GetAll();
            return View(value);
        }
    }
}
