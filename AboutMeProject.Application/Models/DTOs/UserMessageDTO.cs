using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
    public class UserMessageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public string Date { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
