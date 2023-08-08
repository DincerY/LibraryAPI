using LibraryAPI.Application.Repositories.ReadList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadListsController : ControllerBase
    {
        private readonly IReadListReadRepository _readListReadRepository;

        public ReadListsController(IReadListReadRepository readListReadRepository)
        {
            _readListReadRepository = readListReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //hata gözükmesin diye yaptım düzlticem
            throw new Exception();
        }
    }
}
