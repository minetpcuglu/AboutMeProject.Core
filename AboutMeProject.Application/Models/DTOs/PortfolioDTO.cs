using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
   public class PortfolioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Value { get; set; }
        public string Platform { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public string ProjectUrl { get; set; }
    }
}
