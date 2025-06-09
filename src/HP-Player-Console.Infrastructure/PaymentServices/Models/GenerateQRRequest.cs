namespace HP_Player_Console.Infrastructure.PaymentServices.Models;

public record GenerateQRRequest(Guid AccountId, decimal TransactionAmount);
