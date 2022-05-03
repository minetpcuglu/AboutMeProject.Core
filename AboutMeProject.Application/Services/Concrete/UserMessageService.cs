using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Domain.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Concrete
{
    public class UserMessageService : IUserMessageService
    {
        private readonly IUserMessageRepository _userMessageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserMessageService(IUserMessageRepository userMessageRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userMessageRepository = userMessageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(UserMessageDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserMessageDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserMessageDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserMessageDTO>> GetByIdUserMessage(int userId)
        {
            if (userId != 0)
            {
                var messageList = await _userMessageRepository.GetFilteredList(
                    selector: x => new UserMessageDTO
                    {
                        Id = x.Id,
                        Content = x.Content,
                        Title = x.Title,
                        
                      
                        UserId = x.User.Id,
                        UserName = x.User.UserName
                    },
                    expression: x => x.UserId == userId && x.IsActive == true,
                    inculude: x => x.Include(x => x.User)
                    //thenInculude: x => x.Include(x=>x.User)
                    );
                return messageList;
            }
            return null;
        }

        public async Task<List<UserMessageDTO>> GetByIdUserMessageList()
        {
            var messageList = await _userMessageRepository.GetFilteredList(
                     selector: x => new UserMessageDTO
                     {
                         Id = x.Id,
                         Content = x.Content,
                         Title = x.Title,


                         UserId = x.User.Id,
                         UserName = x.User.UserName
                     },
                     //expression: x => x.UserId && x.IsActive == true,
                     inculude: x => x.Include(x => x.User)
                     //thenInculude: x => x.Include(x=>x.User)
                     );
            return messageList;
        }

        public Task Update(UserMessageDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
