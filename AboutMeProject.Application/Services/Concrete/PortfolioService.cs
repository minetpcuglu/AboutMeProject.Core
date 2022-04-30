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

        public async Task Add(PortfolioDTO t)
        {
            var addPortfolio = _mapper.Map<PortfolioDTO, Portfolio>(t);
            addPortfolio.IsActive = true;
            addPortfolio.IsDeleted = false;
            await _unitOfWork.PortfolioRepository.Insert(addPortfolio);
            await _unitOfWork.Commit();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.PortfolioRepository.AnyAsync(a => a.Id == id);
            if (result == true)
            {
                var person = await _unitOfWork.PortfolioRepository.GetAsync2(a => a.Id == id);
                person.IsDeleted = true;
                person.IsActive = false;

                await _unitOfWork.PortfolioRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<PortfolioDTO>> GetAll()
        {
        
            var portfolioList = await _unitOfWork.PortfolioRepository.GetListAll(x=>x.IsActive==true);
            var list = _mapper.Map<List<PortfolioDTO>>(portfolioList);
            await _unitOfWork.Commit();
            return list;
        }

        public async Task<PortfolioDTO> GetById(int id)
        {
            var port = await _unitOfWork.PortfolioRepository.GetById(id);
            return _mapper.Map<PortfolioDTO>(port);
        }

        public Task Update(PortfolioDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
