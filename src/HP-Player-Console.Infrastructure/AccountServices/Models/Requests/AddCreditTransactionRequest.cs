namespace HP_Player_Console.Infrastructure.AccountServices.Models.Requests;

public record AddCreditTransactionRequest(Guid AccountId, string TransactionNo, decimal Amount, string? Notes)
{
    public string ModeOfTransaction { get; set; } = "App";
}
