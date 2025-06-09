namespace HP_Player_Console.Infrastructure.AccountServices.Models.Requests;

public record AddDebitTransactionRequest(string TransactionNo, decimal Amount, string Notes);