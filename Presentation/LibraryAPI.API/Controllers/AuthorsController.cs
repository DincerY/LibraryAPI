using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Authors.Commands.Create;
using LibraryAPI.Application.Features.Authors.Queries.GetAll;
using LibraryAPI.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    { 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllAuthorQuery query = new();
            GetAllAuthorResponse response = await MediatoR.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {

            CreatedAuthorResponse response = await MediatoR.Send(command);
            return Created("", response);
        }
    }
}
