using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
   public class EducationDTO
    {
        public int Id { get; set; }
        public string SchollName { get; set; }
        public string Section { get; set; }
        public string Date { get; set; }
        public string NoteAvarage { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
