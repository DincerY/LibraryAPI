using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.ViewModels.Libraries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        readonly ILibraryService _libraryService;

        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibrary()
        {
            var result =await _libraryService.GetAllLibraries();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibrary([FromBody]Library_Create_VM libraryCreateVm)
        {
            var result =await _libraryService.CreateLibrary(libraryCreateVm);
            return Ok(result);
        }
    }
}
