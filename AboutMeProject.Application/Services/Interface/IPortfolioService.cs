using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Interface
{
   public interface IPortfolioService : IGenericService<PortfolioDTO>
    {
        public Task<int> GetTotelPortfolio();
       public Task<List<Last5ProjectVM>> Last5Project();
    }
}
