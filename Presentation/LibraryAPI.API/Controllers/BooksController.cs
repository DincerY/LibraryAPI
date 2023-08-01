using System.IdentityModel.Tokens.Jwt;
using LibraryAPI.Application.Abstractions.Services;
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

    public class BooksController : ControllerBase
    {
        readonly IBookService _bookService;
         readonly IDistributedCache _distributedCache;

        public BooksController(IBookService bookService, IDistributedCache distributedCache)
        {
            _bookService = bookService;
            _distributedCache = distributedCache;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            List<Book> result =await _bookService.GetAllBooksAsync();
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]string id)
        {
            var result =await _bookService.GetBookByIdAsync(id);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]Book_Create_VM bookCreateVm)
        {
            var result = await _bookService.CreateBookAsync(bookCreateVm);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromQuery]string id,string a)
        {
            var result =await _bookService.UpdateBookAsync(id, a);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]string id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            return Ok(result);
        }
    }
}
