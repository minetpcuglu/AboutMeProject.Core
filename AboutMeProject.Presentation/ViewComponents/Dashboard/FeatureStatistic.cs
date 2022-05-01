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
        private readonly ISkillService _skillService;
        private readonly IMessageService _messageService;
        private readonly IPortfolioService _portfolioService;
        private readonly IEducationService _educationService;

        public FeatureStatistic(IFeatureService featureService, ISkillService skillService, IMessageService messageService, IPortfolioService portfolioService, IEducationService educationService)
        {
            _featureService = featureService;
            _skillService = skillService;
            _messageService = messageService;
            _portfolioService = portfolioService;
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.FeatureCount= await _featureService.GetTotelFeature();
            ViewBag.SkillCount= await _skillService.GetTotelSkill();
            ViewBag.PortfolioCount = await _portfolioService.GetTotelPortfolio();
            ViewBag.ReadMessageCount = await _messageService.GetTotelReadMessage();
            ViewBag.NotReadMessageCount = await _messageService.GetTotelNotReadMessage();
            return View();
        }
    }
}
