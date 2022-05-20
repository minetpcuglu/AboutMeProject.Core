using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class AdminNavbarToDoList : ViewComponent
    {
        private readonly IToDoListService _toDoListService;

        public AdminNavbarToDoList(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var value = await _toDoListService.GetAll();

            //ViewBag.MessageCount = await _messageService.GetTotelMessageCount(p);
            return View(value);
        }
    }
}
