using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetCashoutHistory;

public class GetCashoutHistoryQueryHandler(IAccountServiceApi accountServiceApi) : IRequestHandler<GetCashoutHistoryQuery, ApiBaseResponse<WalletTransactionVm>>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;

    public async Task<ApiBaseResponse<WalletTransactionVm>> Handle(GetCashoutHistoryQuery request, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<WalletTransactionVm>();
        var searchTransactionRequest = new SearchTransactionRequest
        {
            SearchKey = TransactionReferenceTypes.ACCOUNT_WITHDRAW,
            TransactionType = 1,
            PageSize = 20
        };

        try
        {
            var cashOutCredits = await _accountServiceApi.GetWalletTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

            searchTransactionRequest.PageSize = 100;

            var cashOutTransactions = cashOutCredits.Transactions.Select(c =>
            {
                var walletTransaction = new WalletTransactionDto
                {
                    Id = c.Id,
                    TransactionType = "CASH-OUT",
                    TransactionDate = $"{c.TransactionDate:MM-dd-yyyy HH:mm:ss}",
                    TransactionNo = c.TransactionNo,
                    Notes = c.Notes,
                    Amount = c.Amount * -1,
                    CreditResult = c.Credit
                };

                return walletTransaction;
            }).OrderByDescending(o => o.TransactionDate);

            response.Data = new WalletTransactionVm(cashOutTransactions)
            {
                Size = cashOutCredits.TransactionCount,
                Offset = cashOutCredits.Offset,
                Total = cashOutCredits.TotalCount
            };
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }

        return response;
    }
}
