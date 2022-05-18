using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class ContactSubPlaceController : Controller
    {
        private readonly IContactService _contactService;

        public ContactSubPlaceController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetList()
        {
            var value = await _contactService.GetAll();
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _contactService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(ContactDTO contactDTO)
        {
                await _contactService.Update(contactDTO);
                return RedirectToAction("Index", "Default");

        }
    }
}
