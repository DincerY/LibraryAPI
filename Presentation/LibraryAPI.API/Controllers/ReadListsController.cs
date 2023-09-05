using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Features.ReadLists.Queries.GetAll;
using LibraryAPI.Application.Features.ReadLists.Queries.GetById;
using LibraryAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadListsController : BaseController
    {
        private readonly IReadListService _readListService;
        public ReadListsController(IReadListService readListService)
        {
            _readListService = readListService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllReadListQuery query = new();
            GetAllReadListReponse response =await MediatoR.Send(query);
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            GetByUserIdReadListQuery query = new() { UserId = Guid.Parse(userId) };
            GetByUserIdReadListResponse response = await MediatoR.Send(query);
            return Ok(response);
        }

    }
}
