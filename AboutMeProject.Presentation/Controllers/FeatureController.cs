using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IValidator<FeatureDTO> _featureValidator;

        public FeatureController(IFeatureService featureService, IValidator<FeatureDTO> featureValidator)
        {
            _featureService = featureService;
            _featureValidator = featureValidator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _featureService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(FeatureDTO featureDTO)
        {


            var validateResult = _featureValidator.Validate(featureDTO);
            if (validateResult.IsValid)
            {
                await _featureService.Update(featureDTO);
                return RedirectToAction("Index","Default");
            }
            else
            {
                foreach (var error in validateResult.Errors) ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(featureDTO);

        }
    }
}
