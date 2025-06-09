using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ApiBaseController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
