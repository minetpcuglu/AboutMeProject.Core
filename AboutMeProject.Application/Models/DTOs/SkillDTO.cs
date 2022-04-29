using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
   public class SkillDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
        public string IsDeleted { get; set; } 
        public string Value { get; set; }
    }
}
