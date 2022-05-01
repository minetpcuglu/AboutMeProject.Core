using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.VMs
{
   public class Last5ProjectVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Image { get; set; }
        public int TotalProject { get; set; }
        public string TotalPrice { get; set; }
    
        public IEnumerable<Last5ProjectVM> models { get; set; }
    }
}
