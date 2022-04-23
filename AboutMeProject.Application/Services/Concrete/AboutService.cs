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
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AboutService(IAboutRepository aboutRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(AboutDTO aboutDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AboutDTO>> GetAll()
        {
            var aboutList = await _unitOfWork.AboutRepository.GetAll();
            var list = _mapper.Map<List<AboutDTO>>(aboutList);
            await _unitOfWork.Commit();
            //var newList = hobbyList.AsQueryable().Select(x => new HobbyDTO { Id = x.Id, MyHobby = x.MyHobby }); automapper kullanmazsak
            return list;

        }

        public Task<AboutDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AboutDTO aboutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
