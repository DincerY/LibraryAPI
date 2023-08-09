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
        public ReadListsController(IReadListService readListService)
        {
            _readListService = readListService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            ReadListListModel result = _readListService.Get();
            return Ok(result);
        }
    }
}
