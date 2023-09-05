using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Books.Queries.GetAll;
using LibraryAPI.Application.Features.Libraries.Commands.Create;
using LibraryAPI.Application.Features.Libraries.Queries.GetAll;
using LibraryAPI.Application.ViewModels.Libraries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllLibrary()
        {
            GetAllLibraryQuery query = new();
            GetAllLibraryResponse response =await MediatoR.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibrary([FromBody]CreateLibraryCommand createLibraryCommand)
        {
            CreatedLibraryResponse response = await MediatoR.Send(createLibraryCommand);
            return Ok(response);
        }
    }
}
