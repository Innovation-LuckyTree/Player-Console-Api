using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Commands.ProcessBetCommand;

public class ProcessBetPaymentCommandHandler(IAccountServiceApi accountServiceApi) : IRequestHandler<ProcessBetCommand, bool>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;

    public async Task<bool> Handle(ProcessBetCommand request, CancellationToken cancellationToken)
    {
        if (request.IsBonus)
            return await ProcessBonusTransaction(request, cancellationToken);

        var walletRequest = new AddCreditTransactionRequest(request.Account.AccountCreditId, request.TransactionNo, request.Amount, "HP ORDER");
        var betSuccess = await _accountServiceApi.AddBet(walletRequest, cancellationToken);
        return betSuccess;
    }

    public async Task<bool> ProcessBonusTransaction(ProcessBetCommand request, CancellationToken cancellationToken)
    {
        var bonusAccount = await _accountServiceApi.GetBonusAccount(request.Account.AccountBonusId, cancellationToken);

        if ((bonusAccount.PromotionDetails?.Count() ?? 0) == 0)
        {
            return false;
        }

        // TODO: choose the right promotion to use
        var runningBonus = bonusAccount.PromotionDetails.FirstOrDefault();
        var bonusBetRequest = new AddBetUsingBonusRequest(bonusAccount.AccountId, request.TransactionNo, request.Amount, "HP BONUS ORDER")
        {
            PromotionId = runningBonus.PromotionId,
            DateStarted = runningBonus.DateStarted,
            DateExpired = runningBonus.ExpirationDate
        };

        var betResponse = await _accountServiceApi.AddBetUsingBonusAccount(bonusBetRequest, cancellationToken);

        return true;
    }
}