using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        private readonly IMessageUserService _messageService;

        public AdminNavbarMessageList(IMessageUserService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string p = "Admin@gmail.com";
            var value = await _messageService.GetListReceiverMessage(p);

            return View(value);
        }
    }
}
