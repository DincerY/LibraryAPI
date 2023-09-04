using System.IdentityModel.Tokens.Jwt;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.Books;
using LibraryAPI.Application.Features.Books.Commands.Create;
using LibraryAPI.Application.Features.Books.Commands.Delete;
using LibraryAPI.Application.Features.Books.Commands.Update;
using LibraryAPI.Application.Features.Books.Queries.GetAll;
using LibraryAPI.Application.Features.Books.Queries.GetById;
using LibraryAPI.Application.ViewModels.Books;
using LibraryAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 

    public class BooksController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            GetAllBookQuery query = new();
            List<GetAllBookResponse> allBooks =await MediatoR.Send(query);
            return Ok(allBooks);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]string id)
        {
            GetByIdBookQuery query = new() { Id = Guid.Parse(id) };
            GetByIdBookResponse response = await MediatoR.Send(query);
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateBookCommand createBookCommand)
        {
            CreatedBookResponse response = await MediatoR.Send(createBookCommand);
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromQuery]Guid id,string description)
        {
            UpdateBookCommand command = new() { Description = description, Id = id };
            UpdatedBookResponse response = await MediatoR.Send(command);
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]string id)
        {
            DeleteBookCommand command = new() { Id = Guid.Parse(id) };
            DeletedBookResponse response = await MediatoR.Send(command);
            return Ok(response);
        }
    }
}
