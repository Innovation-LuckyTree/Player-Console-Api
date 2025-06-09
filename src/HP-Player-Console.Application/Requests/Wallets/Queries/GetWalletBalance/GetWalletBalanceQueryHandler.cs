using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetWalletBalance;

public class GetWalletBalanceQueryHandler(IAccountServiceApi accountServiceApi, ICoreApi coreApi) : IRequestHandler<GetWalletBalanceQuery, AccountBalanceResponse>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<AccountBalanceResponse> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
    {
        var currentAccount = await _coreApi.AccountCurrent(cancellationToken);

        var accountCredits = await _accountServiceApi.GetAccountBalanceByAccountId(currentAccount.AccountObjectId, cancellationToken);

        return accountCredits;

    }
}