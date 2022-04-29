using AboutMeProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Interface
{
   public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        //DateTime? ModifiedDate { get; set; }
        //DateTime? DeleteDate { get; set; }
        //Status Status { get; set; }
    }
}
