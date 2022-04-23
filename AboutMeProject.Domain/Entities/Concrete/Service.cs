using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class Service : BaseEntity<int>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
