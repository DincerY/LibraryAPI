using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Abstractions.Token;
using LibraryAPI.Application.DTOs.Token;
using LibraryAPI.Application.DTOs.User;
using LibraryAPI.Application.Exceptions;
using LibraryAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager; 
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<LoginUserResponse> LoginUserAsync(LoginUser loginUser)
        {
            LoginUserResponse response = new() {  };

            AppUser user;
            user = await _userManager.FindByNameAsync(loginUser.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginUser.EmailOrUsername);
            }

            if (user == null)
            {
                //throw new NotFoundUserException("Kullanıcı veya şifre hatalı");
                //return new LoginUserResponse()
                //{
                //    Succeeded = false,
                //    Message = "Kullanıcı veya şifre hatalı",
                //};
                response.Succeeded = false;
                response.Message = "Kullanıcı veya şifre hatalı";
                return response;
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
            response.Succeeded = result.Succeeded;
            if (result.Succeeded)
            {
                response.Message = "Giriş Başarılı";
                response.Token = _tokenHandler.CreateAccessToken(15);
                if (response.Token.RefreshToken != null)
                {
                    await _userService.UpdateRefreshTokenAsync(user,response.Token.RefreshToken,response.Token.ExpirationDate,15);
                }
            }
            else
            {
                if (loginUser.Password == null  ||  loginUser.Password == "")
                {
                    response.Message = "Şifreyi boş bıraktınız";
                    return response;
                }
                response.Message = "Giriş Başarısız, Kullanıcı veya şifre hatalı";
            }
            return response;
        }

        public async Task<LoginUserResponse> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15);
                await _userService.UpdateRefreshTokenAsync(user, token.RefreshToken, token.ExpirationDate, 10);
                return new LoginUserResponse
                {
                    Message = "Refresh token ile giriş başarılı",
                    Succeeded = true,
                    Token = token
                };
            }
            else
            {
                return new LoginUserResponse()
                {
                    Message = "Giriş başarısız",
                    Succeeded = false,
                };
            }
        }
    }
}
