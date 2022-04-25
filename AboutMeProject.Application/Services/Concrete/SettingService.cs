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
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(ISettingRepository settingRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task Add(ServiceDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceDTO>> GetAll()
        {
            var settingList = await _unitOfWork.SettingRepository.GetAll();
            var list = _mapper.Map<List<ServiceDTO>>(settingList);
            await _unitOfWork.Commit();
            return list;
        }

        public Task<ServiceDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ServiceDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
