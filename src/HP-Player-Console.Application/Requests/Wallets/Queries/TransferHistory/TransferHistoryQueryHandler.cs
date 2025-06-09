using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.TransferHistory;

public class TransferHistoryQueryHandler : IRequestHandler<TransferHistoryQuery, ApiBaseResponse<WalletTransactionVm>>
{
    private readonly IAccountServiceApi _accountServiceApi;

    public TransferHistoryQueryHandler(IAccountServiceApi accountServiceApi)
    {
        _accountServiceApi = accountServiceApi;
    }

    public async Task<ApiBaseResponse<WalletTransactionVm>> Handle(TransferHistoryQuery request, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<WalletTransactionVm>();

        var searchTransactionRequest = new SearchTransactionRequest
        {
            SearchKey = "TRANSFER",
            TransactionType = null,
        };

        try
        {
            var transferCredits = await _accountServiceApi.GetCreditTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

            searchTransactionRequest.PageSize = 50;
            var walletTransfers = await _accountServiceApi.GetWalletTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

            var transferTransactions = transferCredits.Transactions.OrderByDescending(o => o.TransactionDate).Select(c =>
            {
                var walletTransaction = new WalletTransactionDto
                {
                    TransactionType = c.TransactionReference,
                    TransactionDate = $"{c.TransactionDate:MM-dd-yyyy}",
                    Amount = c.Amount,
                    CreditResult = c.Credit,
                    IsTransfer = true
                };

                var walletBalance = walletTransfers.Transactions.Where(o => o.TransactionNo == c.TransactionNo).FirstOrDefault()?.Credit;

                walletTransaction.WalletResult = walletBalance ?? walletTransfers.Transactions.First().Credit;

                return walletTransaction;
            });

            response.Data = new WalletTransactionVm(transferTransactions)
            {
                Size = transferCredits.TransactionCount,
                Offset = transferCredits.Offset,
                Total = transferCredits.TotalCount
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