using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetBonusHistory;

public class GetBonusHistoryQueryHandler(IAccountServiceApi accountServiceApi, ICoreAccountApi coreAccountApi) : IRequestHandler<GetBonusHistoryQuery, BonusAccountDto>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<BonusAccountDto> Handle(GetBonusHistoryQuery request, CancellationToken cancellationToken)
    {
        var account = await _coreAccountApi.AccountCurrent(cancellationToken);
        var searchString = GetSearchString(request.TransactionType);

        var searchRequest = new SearchTransactionRequest
        {
            AccountId = account.AccountBonusId,
            PageSize = request.PagedQuery.PageSize,
            SearchKey = searchString,
            Start = request.PagedQuery.PageNumber * request.PagedQuery.PageSize,
            StartDate = request.StartDate ?? DateTime.Now.AddDays(-100),
            EndDate = request.EndDate ?? DateTime.Now
        };

        var result = await _accountServiceApi.GetBonusTransactions<BonusAccountDto>(searchRequest, cancellationToken);

        return result;
    }

    private string GetSearchString(int? transactionType)
        => transactionType switch
        {
            1 => "Receive",
            2 => "Expire",
            3 => "ORDER",
            _ => ""
        };

}
