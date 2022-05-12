using AboutMeProject.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Interface
{
   public interface IAnnouncementService : IGenericService<AnnouncementDTO>
    {
        public Task<int> GetTotelAnnouncoment();
        public Task<List<Last5NotificationDTO>> Take5List();
    }
}
