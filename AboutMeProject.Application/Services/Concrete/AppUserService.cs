using AboutMeProject.Application.Models.VMs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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

        public async Task<EditProfileViewModel> GetById(int id)  //ikiside calısıyor
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: x => new EditProfileViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.UserName,
                    Surname = x.Surname,
                    ImageUrl=x.ImageUrl,
                },
                expression: x => x.Id == id);

            return user;
        }

        public async Task EditUser(EditProfileViewModel model)
        {
            var user = await _unitOfWork.AppUserRepository.GetById(model.Id);
            if (user != null)
            {
                if (model.Image != null)
                {
                    using var image = Image.Load(model.Image.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save("wwwroot/images/users/" + user.UserName + ".jpg");
                    user.ImageUrl = ("/images/users/" + user.UserName + ".jpg");
                    await _unitOfWork.AppUserRepository.Update(user);
                    await _unitOfWork.Commit();
                }


                if (model.UserName != user.UserName)
                {
                    var isUserNameExist = await _userManager.FindByNameAsync(model.UserName);

                    if (isUserNameExist == null)
                    {
                        await _userManager.SetUserNameAsync(user, model.UserName);
                        user.UserName = model.UserName;
                        await _signInManager.SignInAsync(user, isPersistent: true);
                    }
                }
                if (model.Name != user.Name)
                {
                    user.Name = model.Name;
                    await _unitOfWork.AppUserRepository.Update(user);
                    await _unitOfWork.Commit();
                }
                if (model.Surname != user.Surname)
                {
                    user.Surname = model.Surname;
                    await _unitOfWork.AppUserRepository.Update(user);
                    await _unitOfWork.Commit();
                }

                //if (model.Email != user.Email)
                //{
                //    var isEmailExist = await _userManager.FindByEmailAsync(model.Email);
                //    if (isEmailExist == null)
                //        await _userManager.SetEmailAsync(user, model.Email);
                //}

                if (model.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    await _userManager.UpdateAsync(user);
                }

            }
        }

    }
}
