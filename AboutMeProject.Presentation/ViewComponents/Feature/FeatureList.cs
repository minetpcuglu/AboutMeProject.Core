using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Presentation.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {

       public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
