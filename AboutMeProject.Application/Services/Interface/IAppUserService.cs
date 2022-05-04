using AboutMeProject.Application.Models.VMs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Interface
{
   public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterViewModel appUserView);
        Task<SignInResult> Login(LoginViewModel loginVM);
        //Task EditUser(EditProfileViewModel editProfileViewModel);
        //Task<EditProfileViewModel> GetById(int id);
        //Task<EditProfileViewModel> GetUserName(string userName);
        //Task LogOut();
    }
}
