using AboutMeProject.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Interface
{
    public interface IMessageUserService : IGenericService<MessageUserDTO>
    {
        Task<List<MessageUserDTO>> GetAllFilter(string mail);
        Task<List<MessageUserDTO>> GetListSenderMessage(string mail);
        Task<List<MessageUserDTO>> GetListReceiverMessage(string mail);
        //Task<List<MessageUserDTO>> Take5GetListReceiverMessage(string mail);
        Task<List<Take5ListReceiverMessageDTO>> Take5List(string mail);
        public Task<int> GetTotelMessage();
        public Task<int> GetTotelMessageCount(string mail);
    }
}
