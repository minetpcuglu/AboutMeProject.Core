using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class Skill : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
