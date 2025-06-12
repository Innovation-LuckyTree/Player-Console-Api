namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Withdrawals;

public record WithdrawalVmResponse(IEnumerable<WithdrawalInfoResponse> Withdrawals)
{
    public int TotalCount { get; set; }
    public int Count { get; set; }
    public int PendingCount { get; set; }
    public int CompletedCount { get; set; }
    public int DeclinedCount { get; set; }
}

public class WithdrawalInfoResponse
{
    public long TransactionId { get; set; }
    public string TransactionNo { get; set; }
    public long AccountInfoId { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public int Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Remarks { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
}
