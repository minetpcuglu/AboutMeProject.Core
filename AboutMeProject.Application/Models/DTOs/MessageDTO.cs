using AboutMeProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }

        //private DateTime _createDate = DateTime.Now;
        //public DateTime CreateDate { get => _createDate; set => value = _createDate; }

        //private Status _status = Status.Active;
        //public Status Status { get => _status; set => value = _status; }

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
    }
}
