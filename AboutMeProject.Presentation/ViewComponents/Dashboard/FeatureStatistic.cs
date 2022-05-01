using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class FeatureStatistic : ViewComponent
    {
        private readonly IFeatureService _featureService;
    
        public FeatureStatistic(IFeatureService featureService)
        {
         
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _featureService.GetAll();
            return View(value);
        }
    }
}
