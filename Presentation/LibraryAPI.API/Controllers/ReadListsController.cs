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
        private readonly IMapper _mapper;
        public ReadListsController(IReadListService readListService, IMapper mapper)
        {
            _readListService = readListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string userId;
            string readListItem;
            string user;
            string userName, userSurname;
            Guid id;
            List<ReadList> result =await _readListService.GetAsync();
            IEnumerable<ICollection<ReadListItem>> readList = result.Select(r => r.ReadListItems);
            IEnumerable<string> userNamee = result.Select(r => r.User.Name);
            return Ok(readList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            ReadList result = await _readListService.GetUsersReadListAsync(id);

            ReadListDto dto = _readListService.ReadListToReadListDto(result);
            return Ok(dto);
        }

    }
}
