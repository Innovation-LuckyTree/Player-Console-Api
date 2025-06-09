namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;

public class UpdateWithdrawalStatusRequest
{
    public long TransactionId { get; set; }
    public int Status { get; set; }
}
