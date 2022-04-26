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

        public Task<bool> Delete(int id)
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

        public Task Update(MessageDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
