using AboutMeProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.Validations.FluentValidation
{
   public class SettingValidation : AbstractValidator<ServiceDTO>
    {
        public SettingValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Avarage is not null");
        }
    }
}
