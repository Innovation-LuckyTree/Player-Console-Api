using HP_Player_Console.Application.Requests.Limits.Queries.GetCompanyGameLimits;
using HP_Player_Console.Application.Requests.Limits.Queries.GetDepositLimit;
using HP_Player_Console.Application.Requests.Limits.Queries.GetWalletLimit;
using HP_Player_Console.Application.Requests.Limits.Queries.GetWithdrawalLimit;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controller;

public class LimitsController : ApiBaseController
{
    /// <summary>
    /// GET withdrawal limit for the day
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("withdrawal")]
    public async Task<IActionResult> GetWithdrawalLimit(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetWithdrawalLimitQuery(), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// GET deposit limit for the day
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("deposit")]
    public async Task<IActionResult> GetDepositLimit(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetDepositLimitQuery(), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// GET wallet limit
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("wallet")]
    public async Task<IActionResult> GetWalletLimit(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetWalletLimitQuery(), cancellationToken);

        return Ok(result);
    }
}