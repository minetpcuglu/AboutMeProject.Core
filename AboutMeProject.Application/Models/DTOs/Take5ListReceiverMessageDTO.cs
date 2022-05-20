using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
   public class Take5ListReceiverMessageDTO
    {
        public int Id { get; set; }
        public string SenderMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public int TotalMail { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Take5ListReceiverMessageDTO> models { get; set; }
    }
}
