using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Withdrawals;

namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetPendingWithdrawals;

public class AccounBalanceWithdrawal(WithdrawalInfoResponse response, CurrentAccountResponse account)
{
    public long TransactionId { get; set; } = response.TransactionId;
    public string TransactionNo { get; set; } = response.TransactionNo;
    public decimal Amount { get; set; } = response.Amount;
    public int Status { get; set; } = response.Status;
    public DateTime TransactionDate { get; set; } = response.TransactionDate;
    public string BranchName { get; set; } = account.BranchName;
    public string BranchAddress { get; set; } = account.BranchAddress;
}