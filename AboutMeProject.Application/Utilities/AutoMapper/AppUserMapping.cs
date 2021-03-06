using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Domain.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.AutoMapper
{
   public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, RegisterViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<RegisterViewModel, AppUser>().ReverseMap();
            CreateMap<AppUserDTO, AppUser>().ReverseMap();
        }
    }
}
