namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;

public record CreateAccountWithdrawalRequest(decimal Amount)
{
    public long AccountId { get; set; }
    public string PaymentMethod { get; set; } = "GCash";
    public DateTime TransactionDate { get; set; } = DateTime.Now;
}
