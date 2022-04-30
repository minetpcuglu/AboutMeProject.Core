using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IValidator<PortfolioDTO> _portfolioValidator;

        public PortfolioController(IPortfolioService portfolioService, IValidator<PortfolioDTO> portfolioValidator)
        {
            _portfolioService = portfolioService;
            _portfolioValidator = portfolioValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetList()
        {
            var value = await _portfolioService.GetAll();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioDTO portfolio)
        {
            var validateResult = _portfolioValidator.Validate(portfolio);
            if (validateResult.IsValid)
            {
                await _portfolioService.Add(portfolio);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(portfolio);

        }


        [HttpPost]
        public async Task<IActionResult> PortfolioDelete(int id)
        {
            if (id != 0)
            {
                var result = await _portfolioService.DeleteAsync(id);
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
                //return RedirectToAction("GetList");

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var value = await _portfolioService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioDTO portfolioDTO)
        {


            var validateResult = _portfolioValidator.Validate(portfolioDTO);
            if (validateResult.IsValid)
            {
                await _portfolioService.Update(portfolioDTO);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(portfolioDTO);

        }
    }
}
