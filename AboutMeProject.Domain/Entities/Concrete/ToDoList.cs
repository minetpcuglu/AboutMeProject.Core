using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class ToDoList : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
    }
}
