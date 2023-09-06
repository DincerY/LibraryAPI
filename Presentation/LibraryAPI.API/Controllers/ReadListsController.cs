using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.Features.ReadLists.Queries.GetAll;
using LibraryAPI.Application.Features.ReadLists.Queries.GetById;
using LibraryAPI.Domain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Events;


namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadListsController : BaseController
    {
        private readonly IReadListService _readListService;
        private readonly IPublishEndpoint _publishEndpoint;
        public ReadListsController(IReadListService readListService, IPublishEndpoint publishEndpoint)
        {
            _readListService = readListService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllReadListQuery query = new();
            GetAllReadListReponse response = await MediatoR.Send(query);
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            GetByUserIdReadListQuery query = new() { UserId = Guid.Parse(userId) };
            GetByUserIdReadListResponse response = await MediatoR.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> FinishReadList(string userId)
        {
            ReadList readList = await _readListService.GetUserReadListAsync(userId);
            ReadListFinishedEvent readListFinishedEvent = new()
            {
                UserId = Guid.Parse(readList.UserId),
                ProductId = readList.ReadListItems.Select(rli=>rli.BookId).ToArray()
            };

            await _publishEndpoint.Publish(readListFinishedEvent);
            return Ok();
        }
    }
}
