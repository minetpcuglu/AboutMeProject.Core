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
   public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(ContactDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactDTO>> GetAll()
        {
            var contactList = await _unitOfWork.ContactRepository.GetAll();
            var list = _mapper.Map<List<ContactDTO>>(contactList);
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<ContactDTO> GetById(int id)
        {
            var contact = await _unitOfWork.ContactRepository.GetById(id);
            return _mapper.Map<ContactDTO>(contact);
        }

        public async Task Update(ContactDTO t)
        {
            var Update = _mapper.Map<ContactDTO, Contact>(t);

            if (Update.Id != 0)
            {
                Update.IsActive = true;
                Update.IsDeleted = false;
                await _contactRepository.Update(Update);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
