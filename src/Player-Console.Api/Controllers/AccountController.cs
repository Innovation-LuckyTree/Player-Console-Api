using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Accounts.Commands.RequestToWithdraw;
using HP_Player_Console.Application.Requests.Accounts.Commands.SetUserToGetVerified;
using HP_Player_Console.Application.Requests.Accounts.Commands.UpdateUserPassword;
using HP_Player_Console.Application.Requests.Accounts.Commands.WithdrawAccountBalance;
using HP_Player_Console.Application.Requests.Accounts.Queries.GetAccountCreditBalance;
using HP_Player_Console.Application.Requests.Accounts.Queries.GetCurrentAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class AccountController : ApiBaseController
{
    [HttpGet("current")]
    public async Task<IActionResult> AccountCurrent(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCurrentAccountQuery(), cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet("credit/balance")]
    public async Task<IActionResult> AccountCreditBalance([FromQuery] GetAccountCreditBalanceQuery query, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(query, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> WithdrawAccountBalance(WithdrawAccountBalanceCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpPost("withdraw/request")]
    public async Task<IActionResult> RequestToWithdraw(RequestToWithdrawCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpPost("password")]
    [AllowAnonymous]
    public async Task<IActionResult> ChangePassword([FromBody] UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPatch("get-verified")]
    public async Task<IActionResult> GetVerified(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new SetUserToGetVerifiedCommand(), cancellationToken);

        return Ok(result);
    }
}
