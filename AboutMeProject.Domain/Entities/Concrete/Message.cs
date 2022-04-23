using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
  public class Message : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
    }
}
