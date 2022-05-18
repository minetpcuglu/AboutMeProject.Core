using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IMessageUserService _messageuserService;

        public AdminMessageController(IMessageUserService messageuserService)
        {
            _messageuserService = messageuserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AdminSendbox()
        {
            string p;
            p = "admin@gmail.com";
            var value = await _messageuserService.GetListSenderMessage(p);
            return View(value);

        }
        public async Task<IActionResult> AdminReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var value = await _messageuserService.GetListReceiverMessage(p);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> AdminMessageDetail(int id)
        {
            var value = await _messageuserService.GetById(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAdminMessage(int id)
        {
            if (id != 0)
            {
                var result = await _messageuserService.DeleteAsync(id);
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


    }
}
