using AboutMeProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.Validations.FluentValidation
{
   public class PortfolioValidation : AbstractValidator<PortfolioDTO>
    {
        public PortfolioValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Project Name is not null");
        }
    }
}
