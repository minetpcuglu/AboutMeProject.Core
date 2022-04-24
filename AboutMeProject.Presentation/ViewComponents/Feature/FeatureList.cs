using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        private readonly IFeatureService _featureService;
        //private readonly IValidator<EducationVM> _educationValidator;
        public FeatureList(IFeatureService featureService/*, IValidator<EducationVM> educationValidator*/)
        {
            //_educationValidator = educationValidator;
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var itemsTask = GetItemsAsync();
            var value = await _featureService.GetAll();
            //var value =  await _featureService.GetAll();
            return View(value);
        }
    }
}
