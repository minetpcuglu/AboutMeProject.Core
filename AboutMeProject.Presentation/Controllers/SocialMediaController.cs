using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetList()
        {
            var value = await _socialMediaService.GetAll();
            return View(value);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _socialMediaService.GetById(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaDTO socialMediaDTO)
        {  
                await _socialMediaService.Update(socialMediaDTO);
                return RedirectToAction("Index", "Default");
        }
    }
}
