using AboutMeProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.Validations.FluentValidation
{
   public class SkillValidation : AbstractValidator<SkillDTO>
    {
        public SkillValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is not null");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Title must contain at least 3 characters");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value is not null");

        }
    }
}
