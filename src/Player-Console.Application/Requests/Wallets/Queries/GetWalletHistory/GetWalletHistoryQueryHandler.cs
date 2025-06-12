using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetWalletHistory;

public class GetWalletHistoryQueryHandler(IAccountServiceApi accountServiceApi, ICoreAccountApi coreAccountApi) : IRequestHandler<GetWalletHistoryQuery, AccountDto>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<AccountDto> Handle(GetWalletHistoryQuery request, CancellationToken cancellationToken)
    {
        var searchString = GetSearchString(request.TransactionType);

        var account = await _coreAccountApi.AccountCurrent(cancellationToken);

        var searchRequest = new SearchTransactionRequest
        {
            AccountId = account.AccountObjectId,
            SearchKey = searchString,
            PageSize = request.PagedQuery.PageSize,
            Start = request.PagedQuery.PageNumber * request.PagedQuery.PageSize,
            StartDate = request.StartDate ?? DateTime.Now.AddDays(-100),
            EndDate = request.EndDate ?? DateTime.Now
        };

        var result = await _accountServiceApi.GetWalletTransactions<AccountDto>(searchRequest, cancellationToken);

        return result;
    }

    private string GetSearchString(int? transactionType)
        => transactionType switch
        {
            1 => "Transfer",
            2 => "DEPOSIT|CREDIT-LOAD",
            3 => "Withdraw",
            4 => "Win",
            _ => ""
        };
}
