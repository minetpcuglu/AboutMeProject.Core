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

        public async Task<int> GetTotelAnnouncoment()
        {
            var query =  _announcementRepository.GetQueryable().Where(x => x.IsActive == true).ToList().Count();

            return query;
        }

        public async Task<List<Last5NotificationDTO>> Take5List()
        {
            var contact = _announcementRepository.GetQueryable().ToList();

            var result = contact.GroupBy(x => x.Title).ToList().Take(5);
            List<Last5NotificationDTO> listModel = new List<Last5NotificationDTO>();

            foreach (var item in result)
            {
                var newModel = new Last5NotificationDTO();
                newModel.Title = item.Key;
                newModel.TotalNotification= item.Count();
                listModel.Add(newModel);
            
            }

            var list =  listModel.OrderByDescending(x => x.TotalNotification).ToList();

            return list;
        }

        public Task Update(AnnouncementDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
