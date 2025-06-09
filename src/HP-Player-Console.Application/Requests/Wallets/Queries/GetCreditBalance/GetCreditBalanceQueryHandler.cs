using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetCreditBalance;

public class GetCreditBalanceQueryHandler(IAccountServiceApi accountServiceApi, ICoreAccountApi coreAccountApi) : IRequestHandler<GetCreditBalanceQuery, AccountBalanceResponse>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<AccountBalanceResponse> Handle(GetCreditBalanceQuery request, CancellationToken cancellationToken)
    {
        var currentAccount = await _coreAccountApi.AccountCurrent(cancellationToken);

        var accountCredits = await _accountServiceApi.GetAccountBalanceByAccountId(currentAccount.AccountCreditId, cancellationToken);

        return accountCredits;

    }
}