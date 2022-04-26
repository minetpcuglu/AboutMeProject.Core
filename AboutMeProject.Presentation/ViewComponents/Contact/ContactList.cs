using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactList(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _contactService.GetAll();
            return View(value);
        }
    }
}
