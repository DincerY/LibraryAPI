using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.User;
using LibraryAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser model)
        {
            CreateUserResponse response = await _userService.CreateUserAsync(model);
            return Ok(response);
        }

    }
    
}
