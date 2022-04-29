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
   public class EducationService:IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EducationService(IEducationRepository educationRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(EducationDTO t)
        {
            var addEducation = _mapper.Map<EducationDTO, Education>(t);
            addEducation.IsActive = true;
            addEducation.IsDeleted = false;
            await _unitOfWork.EducationRepository.Insert(addEducation);
            await _unitOfWork.Commit();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EducationDTO>> GetAll()
        {
            var educationList = await _unitOfWork.EducationRepository.GetListAll(x => x.IsActive == true);
            var list = _mapper.Map<List<EducationDTO>>(educationList);
            await _unitOfWork.Commit();
            return list;
        }

        public Task<EducationDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(EducationDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
