using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetCurrentAccount;

public class GetCurrentAccountQueryHandler : IRequestHandler<GetCurrentAccountQuery, AccountVm>
{
    private readonly ICoreApi _coreApi;
    private readonly IAccountServiceApi _accountServiceApi;

    public GetCurrentAccountQueryHandler(ICoreApi coreApi, IAccountServiceApi accountServiceApi)
    {
        _coreApi = coreApi;
        _accountServiceApi = accountServiceApi;
    }

    public async Task<AccountVm> Handle(GetCurrentAccountQuery request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreApi.AccountCurrent(cancellationToken);

        var accountWallet = await _accountServiceApi.GetAccountBalanceByAccountId(accountInfo.AccountObjectId, cancellationToken);
        var accountCredits = await _accountServiceApi.GetAccountBalanceByAccountId(accountInfo.AccountCreditId, cancellationToken);
        var bonusAccount = await _accountServiceApi.GetBonusAccount(accountInfo.AccountBonusId, cancellationToken);

        return new AccountVm(accountInfo, accountWallet, accountCredits, bonusAccount);
    }
}

