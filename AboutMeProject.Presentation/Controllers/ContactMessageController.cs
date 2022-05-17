using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class ContactMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetList()
        {
            var value = await _messageService.GetAll();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            if (id != 0)
            {
                var result = await _messageService.DeleteAsync(id);
                if (result)
                {
                    return Json(new ToastViewModel
                    {
                        Message = "Deleted.",
                        Success = true
                    });
                }
                else
                {
                    return Json(new ToastViewModel
                    {
                        Message = "Operation Failed.",
                        Success = false
                    });
                }
              

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> ContactMessageDetail(int id)
        {
            var value = await _messageService.GetById(id);
            return View(value);
        }

       
    }
}
