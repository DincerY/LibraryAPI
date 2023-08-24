using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadListsController : ControllerBase
    {
        private readonly IReadListService _readListService;
        public ReadListsController(IReadListService readListService)
        {
            _readListService = readListService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ReadList> result = await _readListService.GetAsync();
            IEnumerable<ReadListDto> readListDtos = result.Select(r => new ReadListDto()
            {
                Id = r.Id,
                ReadListItem = r.ReadListItems.Select(rl => new ReadListItemDto()
                {
                    ReadListItemId = rl.Id,
                    Book = new BookDto()
                    {
                        Id = rl.Book.Id,
                        PageNumber = rl.Book.PageNumber,
                        Title = rl.Book.Title,
                        Description = rl.Book.Description,
                        Authors = rl.Book.Authors.Select(a => new AuthorDto()
                        {
                            AuthorName = a.Name,
                            AuthorSurname = a.Surname,
                        }).ToArray(),
                        Libraries = rl.Book.Librarys.Select(l => new LibraryDto()
                        {
                            LibraryName = l.Name,
                            LibraryAddress = l.Address,
                        }).ToArray()
                    }
                }).ToList(),
                UserName = r.User.Name,
                UserSurname = r.User.Surname,
                UserId = r.User.Id,
                
            });

            return Ok(readListDtos);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {

            ReadList result = await _readListService.GetUsersReadListAsync(userId);

            ReadListDto dto = new ReadListDto()
            {
                Id = result.Id,
                UserId = result.UserId,
                UserName = result.User.Name,
                UserSurname = result.User.Surname,
                ReadListItem = result.ReadListItems.Select(rli => new ReadListItemDto()
                {
                    ReadListItemId = rli.Id,
                    Book = new BookDto()
                    {
                        Id = rli.Book.Id,
                        Description = rli.Book.Description,
                        PageNumber = rli.Book.PageNumber,
                        Title = rli.Book.Title,
                        Authors = rli.Book.Authors.Select(a=>new AuthorDto()
                        {
                            AuthorName = a.Name,
                            AuthorSurname = a.Surname,
                        }).ToArray(),
                        Libraries = rli.Book.Librarys.Select(l=> new LibraryDto()
                        {
                            LibraryName = l.Name,
                            LibraryAddress = l.Address,
                        }).ToArray()
                    }
                }).ToList()
            };
            return Ok(dto);
        }

    }
}
