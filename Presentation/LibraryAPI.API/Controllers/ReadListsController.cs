using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Models;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadListsController : ControllerBase
    {
        private readonly IReadListService _readListService;
        private readonly IMapper _mapper;
        public ReadListsController(IReadListService readListService, IMapper mapper)
        {
            _readListService = readListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ReadList> result =await _readListService.GetAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            ReadList result = await _readListService.GetUsersReadListAsync(id);
            //ReadListDto mappedDto = _mapper.Map<ReadListDto>(result);
            ReadListDto dto = new()
            {
                Id = result.Id,
                ReadListItem = new()
                {
                    Book = new()
                    {
                        Description = result.ReadListItem.Book.Description,
                        Id = result.ReadListItem.BookId,
                        PageNumber = result.ReadListItem.Book.PageNumber,
                        Title = result.ReadListItem.Book.Title,
                    }

                },
                ReadListItemId = result.ReadListItemId,
                UserId = result.UserId,
            };
            return Ok(dto);
        }

    }
}
