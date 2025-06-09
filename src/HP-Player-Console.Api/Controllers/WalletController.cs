using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Wallets.Commands.TransferCreditToWallet;
using HP_Player_Console.Application.Requests.Wallets.Commands.TransferWalletToCredit;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetBonusBalance;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetBonusHistory;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetCashinHistory;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetCashoutHistory;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetCreditBalance;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetWalletBalance;
using HP_Player_Console.Application.Requests.Wallets.Queries.GetWalletHistory;
using HP_Player_Console.Application.Requests.Wallets.Queries.TransferHistory;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class WalletController(ILogger<WalletController> logger) : ApiBaseController
{
    private readonly ILogger<WalletController> _logger = logger;

    [HttpGet("balance")]
    public async Task<IActionResult> GetWalletBalance(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetWalletBalanceQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("credit/balance")]
    public async Task<IActionResult> GetCreditBalance(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCreditBalanceQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("bonus/balance")]
    public async Task<IActionResult> GetBonusBalance(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetBonusBalanceQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("transactions/cashin")]
    public async Task<IActionResult> GetCashinHistory(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCashinHistoryQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("transactions/cashout")]
    public async Task<IActionResult> GetCashoutHistory(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCashoutHistoryQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("transactions/transfers")]
    public async Task<IActionResult> TransferHistory(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new TransferHistoryQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpPost("transfer/credit-wallet")]
    public async Task<IActionResult> TransferCreditToWallet(TransferCreditToWalletCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    [HttpPost("transfer/wallet-credit")]
    public async Task<IActionResult> TransferWalletToCredit(TransferWalletToCreditCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    [HttpPost("history/list")]
    public async Task<IActionResult> GetWalletTransactionHistory(GetWalletHistoryQuery query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost("bonus/history/list")]
    public async Task<IActionResult> GetBonusTransactionHistory(GetBonusHistoryQuery query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}

