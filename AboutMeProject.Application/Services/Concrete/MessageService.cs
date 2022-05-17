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

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.MessageRepository.AnyAsync(a => a.Id == id);
            if (result == true)
            {
                var person = await _unitOfWork.MessageRepository.GetAsync2(a => a.Id == id);
                person.IsDeleted = true;
                person.IsActive = false;

                await _unitOfWork.MessageRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<MessageDTO>> GetAll()
        {
            var List = await _unitOfWork.MessageRepository.GetListAll(x => x.IsActive == true);
            var list = _mapper.Map<List<MessageDTO>>(List);
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<MessageDTO> GetById(int id)
        {
            var message = await _unitOfWork.MessageRepository.GetById(id);
            return _mapper.Map<MessageDTO>(message);
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
