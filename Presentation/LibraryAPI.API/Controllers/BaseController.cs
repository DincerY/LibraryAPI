using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? MediatoR => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


}