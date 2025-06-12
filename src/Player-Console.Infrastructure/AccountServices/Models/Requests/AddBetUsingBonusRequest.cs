namespace HP_Player_Console.Infrastructure.AccountServices.Models.Requests;

public record AddBetUsingBonusRequest(Guid AccountId, string TransactionNo, decimal Amount, string? Notes)
{
    public int PromotionId { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime DateExpired { get; set; }
}











