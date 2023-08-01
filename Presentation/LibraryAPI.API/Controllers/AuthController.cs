using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.Token;
using LibraryAPI.Application.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
           LoginUserResponse response = await _authService.LoginUserAsync(loginUser); 
           return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RequestRefreshToken refreshToken)
        {
            LoginUserResponse response =await _authService.RefreshTokenLoginAsync(refreshToken.RefreshToken);
            return Ok(response);
        }
    }
}
