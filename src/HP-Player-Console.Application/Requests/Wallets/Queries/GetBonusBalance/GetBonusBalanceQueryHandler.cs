using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetBonusBalance;

public class GetBonusBalanceQueryHandler(IAccountServiceApi accountServiceApi, ICoreApi coreApi) : IRequestHandler<GetBonusBalanceQuery, AccountBonusDetail>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<AccountBonusDetail> Handle(GetBonusBalanceQuery request, CancellationToken cancellationToken)
    {
        var currentAccount = await _coreApi.AccountCurrent(cancellationToken);

        var bonusAccount = await _accountServiceApi.GetBonusAccount(currentAccount.AccountBonusId, cancellationToken);

        return bonusAccount;
    }
}
