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
        public async Task Add(ServiceDTO t)
        {
            var add = _mapper.Map<ServiceDTO, Service>(t);
            add.IsActive = true;
            add.IsDeleted = false;
            await _unitOfWork.SettingRepository.Insert(add);
            await _unitOfWork.Commit();
        }

    

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.SettingRepository.AnyAsync(a => a.Id == id);
            if (result == true)
            {
                var person = await _unitOfWork.SettingRepository.GetAsync2(a => a.Id == id);
                person.IsDeleted = true;
                person.IsActive = false;

                await _unitOfWork.SettingRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ServiceDTO>> GetAll()
        {
            var settingList = await _unitOfWork.SettingRepository.GetListAll(x => x.IsActive == true);
            var list = _mapper.Map<List<ServiceDTO>>(settingList);
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<ServiceDTO> GetById(int id)
        {
            var service = await _unitOfWork.SettingRepository.GetById(id);
            return _mapper.Map<ServiceDTO>(service);
        }

        public async Task Update(ServiceDTO t)
        {
            var Update = _mapper.Map<ServiceDTO, Service>(t);

            if (Update.Id != 0)
            {
               Update.IsActive = true;
                Update.IsDeleted = false;
                await _settingRepository.Update(Update);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
