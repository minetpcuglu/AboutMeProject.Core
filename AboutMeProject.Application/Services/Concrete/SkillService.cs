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

        public Task Add(SkillDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SkillDTO>> GetAll()
        {
            var skillList = await _unitOfWork.SkillRepository.GetAll();
            var list = _mapper.Map<List<SkillDTO>>(skillList);
            await _unitOfWork.Commit();
            return list;
        }

        public Task<SkillDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SkillDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
