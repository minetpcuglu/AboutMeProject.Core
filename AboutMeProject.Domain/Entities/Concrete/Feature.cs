using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class Feature : BaseEntity<int>
    {
        public string Haeder { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
