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


        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.EducationRepository.AnyAsync(a => a.Id == id);
            if (result == true)
            {
                var person = await _unitOfWork.EducationRepository.GetAsync2(a => a.Id == id);
                person.IsDeleted = true;
                person.IsActive = false;

                await _unitOfWork.EducationRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<EducationDTO>> GetAll()
        {
            var educationList = await _unitOfWork.EducationRepository.GetListAll(x => x.IsActive == true);
            var list = _mapper.Map<List<EducationDTO>>(educationList);
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<EducationDTO> GetById(int id)
        {
            var education = await _unitOfWork.EducationRepository.GetById(id);
            return _mapper.Map<EducationDTO>(education);
        }

        public async Task<int> GetTotelEducation()
        {
            var query = _educationRepository.GetQueryable().Where(x => x.IsActive == true).ToList().Count();

            return query;
        }

        public async Task Update(EducationDTO t)
        {

            var educationUpdate = _mapper.Map<EducationDTO, Education>(t);

            if (educationUpdate.Id != 0)
            {
                educationUpdate.IsActive = true;
                educationUpdate.IsDeleted = false;
                await _educationRepository.Update(educationUpdate);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
