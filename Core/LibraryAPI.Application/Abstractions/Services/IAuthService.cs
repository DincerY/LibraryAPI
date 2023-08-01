using LibraryAPI.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginUserResponse> LoginUserAsync(LoginUser loginUser);
        Task<LoginUserResponse> RefreshTokenLoginAsync(string refreshToken);
    }
}
