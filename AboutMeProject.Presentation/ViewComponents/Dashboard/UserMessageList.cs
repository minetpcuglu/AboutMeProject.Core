using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class UserMessageList : ViewComponent
    {
        //private readonly IUserMessageService _messageService;

        //public UserMessageList(IUserMessageService messageService)
        //{
        //    _messageService = messageService;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
