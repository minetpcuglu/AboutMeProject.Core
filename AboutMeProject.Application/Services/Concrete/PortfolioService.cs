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
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(PortfolioDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PortfolioDTO>> GetAll()
        {
        
            var portfolioList = await _unitOfWork.PortfolioRepository.GetListAll(x=>x.IsActive==true);
            var list = _mapper.Map<List<PortfolioDTO>>(portfolioList);
            await _unitOfWork.Commit();
            return list;
        }

        public Task<PortfolioDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PortfolioDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
