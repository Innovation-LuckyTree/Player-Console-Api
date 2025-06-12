using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Deposits.Commands.CreateDepositRequest;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class DepositController : ApiBaseController
{
    [HttpPost("request")]
    public async Task<IActionResult> RequestDeposit(CreateDepositRequestCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        
        return Ok(result);
    }
}
