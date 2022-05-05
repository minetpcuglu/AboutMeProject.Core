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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(AnnouncementDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AnnouncementDTO>> GetAll()
        {
            var announcementList = await _unitOfWork.AnnouncementRepository.GetListAll(x => x.IsActive == true);
            var list = _mapper.Map<List<AnnouncementDTO>>(announcementList);
            await _unitOfWork.Commit();
            return list;
        }

        public Task<AnnouncementDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AnnouncementDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
