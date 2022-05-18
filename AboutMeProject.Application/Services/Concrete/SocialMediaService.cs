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
   public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(SocialMediaDTO t)
        {

            var add = _mapper.Map<SocialMediaDTO, SocialMedia>(t);
            add.IsActive = true;
            add.IsDeleted = false;
            await _unitOfWork.SocialMediaRepository.Insert(add);
            await _unitOfWork.Commit();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SocialMediaDTO>> GetAll()
        {
            var mediaList = await _unitOfWork.SocialMediaRepository.GetAll();
            var list = _mapper.Map<List<SocialMediaDTO>>(mediaList);
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<SocialMediaDTO> GetById(int id)
        {
            var media = await _unitOfWork.SocialMediaRepository.GetById(id);
            return _mapper.Map<SocialMediaDTO>(media);
        }

        public async Task Update(SocialMediaDTO t)
        {
            var Update = _mapper.Map<SocialMediaDTO, SocialMedia>(t);

            if (Update.Id != 0)
            {
                Update.IsActive = true;
                Update.IsDeleted = false;
                await _socialMediaRepository.Update(Update);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
