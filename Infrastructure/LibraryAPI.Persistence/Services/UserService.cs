using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Abstractions.Token;
using LibraryAPI.Application.DTOs.User;
using LibraryAPI.Application.Exceptions;
using LibraryAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }
         
        public async Task<CreateUserResponse> CreateUserAsync(CreateUser model)
        {
            bool hasCreated = _userManager.Users.Any(user => user.Email == model.Email);
            if (hasCreated)
            {
                return new()
                {
                    Succeeded = false,
                    Message = "Kullanıcı zaten mevcut"
                };
            }
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Firstname,
                Surname = model.Lastname,
                Email = model.Email,
                Age = model.Age,
                UserName = model.UserName,
            },model.Password);

            CreateUserResponse response = new(){Succeeded = result.Succeeded};

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla oluşturulmuştur";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}";
                }
            }
            return response;
        }


        public async Task UpdateRefreshTokenAsync(AppUser user,string refreshToken,DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserException();
            }
        }

      
    }
}
