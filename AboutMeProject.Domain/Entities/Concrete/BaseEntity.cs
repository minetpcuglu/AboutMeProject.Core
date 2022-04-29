using AboutMeProject.Domain.Entities.Interface;
using AboutMeProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => value = _createDate; }
        public virtual bool IsActive { get; set; } = true;
        public virtual bool IsDeleted { get; set; } = false;

        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeleteDate { get; set; }

        //private Status _status = Status.Active;
        //public Status Status { get => _status; set => value = _status; }

    }
}
