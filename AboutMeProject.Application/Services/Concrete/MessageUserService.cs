using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Domain.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Concrete
{
    public class MessageUserService : IMessageUserService
    {
        private readonly IMessageUserRepository _messageUserRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageUserService(IMessageUserRepository messageUserRepository, UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _messageUserRepository = messageUserRepository;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(MessageUserDTO t)
        {
            var addMessage = _mapper.Map<MessageUserDTO, MessageUser>(t);
            addMessage.IsActive = true;
            addMessage.IsDeleted = false;
            addMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _unitOfWork.MessageUserRepository.Insert(addMessage);
            await _unitOfWork.Commit();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.MessageUserRepository.AnyAsync(a => a.Id == id);
            if (result == true)
            {
                var person = await _unitOfWork.MessageUserRepository.GetAsync2(a => a.Id == id);
                person.IsDeleted = true;
                person.IsActive = false;

                await _unitOfWork.MessageUserRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public Task<List<MessageUserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MessageUserDTO>> GetAllFilter(string mail)
        {
            var messageList = await _unitOfWork.MessageUserRepository.GetListAll(x => x.ReceiverMail==mail);
            return  _mapper.Map<List<MessageUserDTO>>(messageList);
        }

        public async Task<MessageUserDTO> GetById(int id)
        {
            var port = await _unitOfWork.MessageUserRepository.GetById(id);
            return _mapper.Map<MessageUserDTO>(port);
        }

        public async Task<List<MessageUserDTO>> GetListReceiverMessage(string mail)
        {
            var messageList = await _unitOfWork.MessageUserRepository.GetListAll(x => x.ReceiverMail == mail);
            return _mapper.Map<List<MessageUserDTO>>(messageList);
        }

        public async Task<List<MessageUserDTO>> GetListSenderMessage(string mail)
        {
            var messageList = await _unitOfWork.MessageUserRepository.GetListAll(x => x.SenderMail == mail && x.IsActive==true);
            return _mapper.Map<List<MessageUserDTO>>(messageList);
        }

        public async Task<int> GetTotelMessage()
        {
            var query = _messageUserRepository.GetQueryable().ToList().Count();

            return query;
        }

        //public async Task<List<MessageUserDTO>> Take5GetListReceiverMessage(string mail)
        //{
        //    var query = _messageUserRepository.GetQueryable().Where(x => x.ReceiverMail == mail && x.IsActive == true).ToList().Count();

        //    return query;
        //}

        public Task Update(MessageUserDTO t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Take5ListReceiverMessageDTO>> Take5List(string mail)
        {
            var contact = _messageUserRepository.GetQueryable().Where(x=>x.ReceiverMail==mail && x.IsActive==true).ToList();

            var result = contact/*GroupBy(x => x.SenderMail )*/.ToList().Take(5);
            List<Take5ListReceiverMessageDTO> listModel = new List<Take5ListReceiverMessageDTO>();

            foreach (var item in result)
            {
                var newModel = new Take5ListReceiverMessageDTO();
                newModel.SenderMail = item.SenderMail;
                newModel.Subject = item.Subject;
                newModel.SenderName = item.SenderName;
                newModel.Content = item.MessageContent;
                newModel.Date = item.Date;
                listModel.Add(newModel);
            }
            var list = listModel.OrderByDescending(x => x.Id ).ToList();

            return list;
        }
    }
}
