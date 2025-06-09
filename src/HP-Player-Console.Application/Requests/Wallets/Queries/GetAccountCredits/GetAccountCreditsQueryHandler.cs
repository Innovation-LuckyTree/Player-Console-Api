using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetAccountCredits;

public class GetAccountCreditsQueryHandler(IAccountServiceApi accountServiceApi, ICoreApi coreApi) : IRequestHandler<GetAccountCreditsQuery, AccountBalanceResponse>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<AccountBalanceResponse> Handle(GetAccountCreditsQuery request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreApi.AccountCurrent(cancellationToken);

        var accountCredits = await _accountServiceApi.GetAccountBalanceByAccountId(accountInfo.AccountCreditId, cancellationToken);

        return accountCredits;
    }
}
