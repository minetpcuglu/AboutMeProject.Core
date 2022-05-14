using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
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
    public class MessageUserService : IMessageUserService
    {
        private readonly IMessageUserRepository _messageUserRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageUserService(IMessageUserRepository messageUserRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _messageUserRepository = messageUserRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(MessageUserDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MessageUserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MessageUserDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(MessageUserDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
