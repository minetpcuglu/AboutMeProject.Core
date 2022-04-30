using AboutMeProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.Validations.FluentValidation
{
   public class FeatureValidation : AbstractValidator<FeatureDTO>
    {
        public FeatureValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is not null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is not null");
            RuleFor(x => x.Haeder).NotEmpty().WithMessage("Header is not null");

        }
    }
}
