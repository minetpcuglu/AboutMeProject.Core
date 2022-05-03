using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class ToDoList : ViewComponent
    {
        private readonly IToDoListService _todolistService;

        public ToDoList(IToDoListService todolistService)
        {
            _todolistService = todolistService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _todolistService.GetAll();

            return View(value);
        }
    }
}
