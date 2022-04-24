using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        //private readonly IValidator<EducationVM> _educationValidator;
        public AboutController(IAboutService aboutService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> GetList()
        {
            var value =  await _aboutService.GetAll();
            
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var value = await _aboutService.GetAll();

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AboutDTO aboutDTO)
        {
           await _aboutService.Add(aboutDTO);

            return RedirectToAction("GetList");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _aboutService.GetById(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> Update(AboutDTO aboutDTO)
        {


            //var validateResult = _hobbyValidator.Validate(hobbyDTO);
            //if (validateResult.IsValid)
            //{
            await _aboutService.Update(aboutDTO);
            return RedirectToAction("Getlist");
            //}
            //else
            //{
            //    foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //}

            //return View(hobbyDTO);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var result = await _aboutService.Delete(id);
                //if (result)
                //{
                //    return Json(new ToastViewModel
                //    {
                //        Message = "silindi.",
                //        Success = true
                //    });
                //}
                //else
                //{
                //    return Json(new ToastViewModel
                //    {
                //        Message = "İşlem Başarısız.",
                //        Success = false
                //    });
                //}
            }
            return View();
        }

    }
}

