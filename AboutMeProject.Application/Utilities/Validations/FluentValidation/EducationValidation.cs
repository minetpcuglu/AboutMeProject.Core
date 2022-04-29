using AboutMeProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.Validations.FluentValidation
{
   public class EducationValidation : AbstractValidator<EducationDTO>
    {
        public EducationValidation()
        {
            RuleFor(x => x.NoteAvarage).NotEmpty().WithMessage("Note Avarage is not null");
            RuleFor(x => x.SchollName).MinimumLength(3).WithMessage("Scholl Name must contain at least 3 characters");
            RuleFor(x => x.NoteAvarage).MaximumLength(5).WithMessage("Note Avarage must contain at least 5 characters");
            RuleFor(x => x.Section).NotEmpty().WithMessage("Section is not null");
            RuleFor(x => x.SchollName).NotEmpty().WithMessage("Scholl Name is not null");


        }
    }
}
