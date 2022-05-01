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
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FeatureService(IFeatureRepository featureRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task Add(FeatureDTO t)
        {
            throw new NotImplementedException();
        }

       
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FeatureDTO>> GetAll()
        {
            var featureList = await _unitOfWork.FeatureRepository.GetAll();
            var list = _mapper.Map<List<FeatureDTO>>(featureList);
            await _unitOfWork.Commit();
            //var newList = hobbyList.AsQueryable().Select(x => new HobbyDTO { Id = x.Id, MyHobby = x.MyHobby }); automapper kullanmazsak
            return list;
        }

        public async Task<FeatureDTO> GetById(int id)
        {
            var port = await _unitOfWork.FeatureRepository.GetById(id);
            return _mapper.Map<FeatureDTO>(port);
        }

        public async Task<int> GetTotelFeature()
        {
            var query =  _featureRepository.GetQueryable().Where(x => x.IsActive==true).ToList().Count();

            return query;
        }

        public async Task Update(FeatureDTO t)
        {
            var Update = _mapper.Map<FeatureDTO, Feature>(t);

            if (Update.Id != 0)
            {
                Update.IsActive = true;
                Update.IsDeleted = false;
                await _featureRepository.Update(Update);
                await _unitOfWork.SaveChangesAsync();
            }
        }

      
    }
}
