﻿using AboutMeProject.Application.Models.DTOs;
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

        public async Task Add(AboutDTO aboutDTO)
        {

            var addAbout = _mapper.Map<AboutDTO, About>(aboutDTO);
            addAbout.IsActive = true;
            addAbout.IsDeleted = false;
            await _unitOfWork.AboutRepository.Insert(addAbout);
            await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var deleteAbout = await _unitOfWork.AboutRepository.Get(x => x.Id == id);
                deleteAbout.IsActive = false;
                deleteAbout.IsDeleted = true;
                await _unitOfWork.AboutRepository.Delete(deleteAbout);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
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

        public async Task<AboutDTO> GetById(int id)
        {
            var hobby = await _unitOfWork.AboutRepository.GetById(id);
            return _mapper.Map<AboutDTO>(hobby);
        }

        public async Task Update(AboutDTO aboutDTO)
        {
            var aboutUpdate = _mapper.Map<AboutDTO, About>(aboutDTO);

            if (aboutUpdate.Id != 0)
            {
                aboutUpdate.IsActive = true;
                aboutUpdate.IsDeleted = false;
                await _aboutRepository.Update(aboutUpdate);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
