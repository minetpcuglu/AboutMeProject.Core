using AboutMeProject.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Interface
{
   public interface IFeatureService : IGenericService<FeatureDTO>
    {
       public Task<int> GetTotelFeature();
       
    }
}
