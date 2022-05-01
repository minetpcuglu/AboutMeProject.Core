using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Domain.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Concrete
{
   public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(MessageDTO t)
        {
            var addMessage = _mapper.Map<MessageDTO, Message>(t);
            await _unitOfWork.MessageRepository.Insert(addMessage);
            await _unitOfWork.Commit();
           
        }

      

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MessageDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MessageDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotelReadMessage() //okunmus
        {
            var query = _messageRepository.GetQueryable().Where(x => x.IsActive == true).ToList().Count();

            return query;
        }
        public async Task<int> GetTotelNotReadMessage() //okunmamıs
        {
            var query = _messageRepository.GetQueryable().Where(x => x.IsActive == false).ToList().Count();

            return query;
        }

        public Task Update(MessageDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
