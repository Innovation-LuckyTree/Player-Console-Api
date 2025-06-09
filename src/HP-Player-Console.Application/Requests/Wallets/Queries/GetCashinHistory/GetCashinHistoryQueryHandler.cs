using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetCashinHistory;

public class GetCashinHistoryQueryHandler(IAccountServiceApi accountServiceApi, ICoreApi coreApi) : IRequestHandler<GetCashinHistoryQuery, ApiBaseResponse<WalletTransactionVm>>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<ApiBaseResponse<WalletTransactionVm>> Handle(GetCashinHistoryQuery request, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<WalletTransactionVm>();

        var account = await _coreApi.AccountCurrent(cancellationToken);

        var searchTransactionRequest = new SearchTransactionRequest
        {
            AccountId = account.AccountObjectId,
            SearchKey = $"{TransactionReferenceTypes.ACCOUNT_CASH_IN}|{TransactionReferenceTypes.ACCOUNT_CREDIT_LOAD}|{TransactionReferenceTypes.ACCOUNT_CASH_DEPOSIT}"
        };

        try
        {
            var cashInCredits = await _accountServiceApi.GetWalletTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

            searchTransactionRequest.PageSize = 100;
            searchTransactionRequest.SearchKey = "";

            var walletTransactions = await _accountServiceApi.GetCreditTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

            var cashInTransactions = cashInCredits.Transactions.Select(c =>
            {
                var walletTransaction = new WalletTransactionDto
                {
                    Id = c.Id,
                    TransactionType = "CASH-IN",
                    TransactionDate = $"{c.TransactionDate:MM-dd-yyyy HH:mm:ss}",
                    TransactionNo = c.TransactionNo,
                    Notes = c.Notes,
                    Amount = c.Amount,
                    CreditResult = c.Credit
                };

                var nearestWallet = walletTransactions.Transactions.OrderBy(d => (d.TransactionDate - c.TransactionDate).Duration()).First();

                walletTransaction.WalletResult = nearestWallet.Credit;

                return walletTransaction;
            }).OrderByDescending(o => o.TransactionDate);

            response.Data = new WalletTransactionVm(cashInTransactions)
            {
                Size = cashInCredits.TransactionCount,
                Offset = cashInCredits.Offset,
                Total = cashInCredits.TotalCount
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
