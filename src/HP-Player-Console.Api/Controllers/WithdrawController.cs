using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Withdrawals.Queries.GetJackpotWithdraws;
using HP_Player_Console.Application.Requests.Withdrawals.Queries.GetPendingWithdrawals;
using HP_Player_Console.Application.Requests.Withdrawals.Queries.GetWithdrawalDetail;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class WithdrawController(ILogger<WithdrawController> logger) : ApiBaseController
{
    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetWithdrawByTransaction(long transactionId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetWithdrawalDetailQuery(transactionId), cancellationToken);

        return Ok(result);
    }

    [HttpGet("jackpot")]
    public async Task<IActionResult> GetJackpotWithdraw(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetJackpotWithdrawsQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingWithdrawals(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetPendingWithdrawalsQuery(), cancellationToken);

        return Ok(result);
    }
}