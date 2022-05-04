using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class AppUser : IdentityUser<int>
    {
        public int Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => value = _createDate; }
        public virtual bool IsActive { get; set; } = true;
        public virtual bool IsDeleted { get; set; } = false;
    }
}
