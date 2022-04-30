using AboutMeProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.Validations.FluentValidation
{
   public class AboutValidation : AbstractValidator<AboutDTO>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail is not null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is not null");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is not null");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adress is not null");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is not null");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is not null");

        }
    }
}
