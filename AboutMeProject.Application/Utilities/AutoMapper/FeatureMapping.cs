using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Domain.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.AutoMapper
{
   public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,FeatureDTO>().ReverseMap();
            CreateMap<FeatureDTO, Feature>().ReverseMap();
        }
    }
}
