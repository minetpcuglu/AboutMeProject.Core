using AboutMeProject.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Dashboard
{
    public class Last5Project : ViewComponent
    {
       
        private readonly IPortfolioService _portfolioService;

        public Last5Project(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var value = await _portfolioService.Last5Project();
          
            return View(value);
        }
    }
}
