using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public AppUserService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager)

        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
            this._signInManager = signInManager;

        }

        public async Task<SignInResult> Login(LoginViewModel loginVM)
        {
            var user = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, loginVM.Persistent, loginVM.Lock);
            return user;
        
        }


        public async Task<IdentityResult> Register(RegisterViewModel appUserView)
        {
            var user = _mapper.Map<AppUser>(appUserView);

            var result = await _userManager.CreateAsync(user, appUserView.Password);

            if (result.Succeeded) await _signInManager.SignInAsync(user, isPersistent: false);// isPersistent =>Tarayıcı kullanıcı giriş bilgilerini hafıza da tutmsun mu diye sorar

            return result;
        }
    }
}
