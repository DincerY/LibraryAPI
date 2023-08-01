using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    { 
        readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result =await _authorService.GetAllAuthors();
            return Ok(result);
        }
    }
}
