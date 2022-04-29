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
   public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(ISkillRepository skillRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(SkillDTO t)
        {
            var addSkill = _mapper.Map<SkillDTO, Skill>(t);
            addSkill.IsActive = true;
            addSkill.IsDeleted = false;
            await _unitOfWork.SkillRepository.Insert(addSkill);
            await _unitOfWork.Commit();
        }

       

        public async Task<List<SkillDTO>> GetAll()
        {
            var skillList = await _unitOfWork.SkillRepository.GetListAll(x => x.IsActive == true);
            var list = _mapper.Map<List<SkillDTO>>(skillList);         
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<SkillDTO> GetById(int id)
        {
            var skill = await _unitOfWork.SkillRepository.GetById(id);
            return _mapper.Map<SkillDTO>(skill);
        }

        public async Task Update(SkillDTO t)
        {
            var aboutUpdate = _mapper.Map<SkillDTO,Skill>(t);

            if (aboutUpdate.Id != 0)
            {
                aboutUpdate.IsActive = true;
                aboutUpdate.IsDeleted = false;
                await _skillRepository.Update(aboutUpdate);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.SkillRepository.AnyAsync(a => a.Id == id);
            if (result == true)
            {
                var person = await _unitOfWork.SkillRepository.GetAsync2(a => a.Id == id);
                person.IsDeleted = true;
                person.IsActive = false;

                await _unitOfWork.SkillRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
