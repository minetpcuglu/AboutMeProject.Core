using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
    public class Last5NotificationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int TotalNotification { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Last5NotificationDTO> models { get; set; }
    }
}
