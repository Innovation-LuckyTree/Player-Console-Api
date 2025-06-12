using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface IAccountServiceApi
{
    Task<T> GetAccountWalletTransaction<T>(CancellationToken cancellationToken) where T : class;
    Task<AccountBalanceResponse> GetAccountWalletBalance(CancellationToken cancellationToken);
    Task<AccountBalanceResponse> GetAccountBalanceByAccountId(Guid accountId, CancellationToken cancellationToken);
    Task<CurrentAccountTransactionResponse> GetCurrentAccountTransaction(CancellationToken cancellationToken);
    Task<AccountBonusDetail> GetBonusAccount(Guid accountId, CancellationToken cancellationToken);
    Task AccountCashIn(AddDebitTransactionRequest request, CancellationToken cancellationToken);
    Task<bool> AddBet(AddCreditTransactionRequest request, CancellationToken cancellationToken);
    Task<AccountBalanceResponse> AccountWithdraw(AddCreditTransactionRequest request, CancellationToken cancellationToken);
    Task<DepositTokenData> GetDepositToken(DepositTokenRequest request, CancellationToken cancellationToken);
    Task<AccountBalanceResponse> GetAccountCredits(CancellationToken cancellationToken);
    Task<TransferAssetResponse> TransferWalletToCredit(TransferAssetRequest request, CancellationToken cancellationToken);
    Task<TransferAssetResponse> TransferCreditToWallet(TransferAssetRequest request, CancellationToken cancellationToken);
    Task<T> GetWalletTransactions<T>(SearchTransactionRequest request, CancellationToken cancellationToken) where T : class;
    Task<T> GetCreditTransactions<T>(SearchTransactionRequest request, CancellationToken cancellationToken) where T : class;
    Task<bool> AddBetUsingBonusAccount(AddBetUsingBonusRequest request, CancellationToken cancellationToken);
    Task<T> GetBonusTransactions<T>(SearchTransactionRequest request, CancellationToken cancellationToken) where T : class;
}
