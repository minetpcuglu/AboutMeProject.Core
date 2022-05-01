using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class DashboardStatistic : ViewComponent
    {
        private readonly IFeatureService _featureService;
        private readonly ISettingService _settingService;
        private readonly IEducationService _educationService;

        public DashboardStatistic(IFeatureService featureService, ISettingService settingService, IEducationService educationService)
        {
            _featureService = featureService;
            _settingService = settingService;
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.FeatureCount = await _featureService.GetTotelFeature();
            ViewBag.SettingCount = await _settingService.GetTotelSetting();
            ViewBag.EducationCount = await _educationService.GetTotelEducation();
          
            return View();
        }
    }
}
