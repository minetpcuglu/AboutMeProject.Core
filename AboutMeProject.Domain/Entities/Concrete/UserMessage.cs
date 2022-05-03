using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class UserMessage : BaseEntity<int>
    {
        public string Title { get; set; }
      
        public string Content { get; set; }
        public string Date { get; set; }

        public virtual int UserId { get; set; }
        public User User { get; set; }
    }
}
