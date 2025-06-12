namespace HP_Player_Console.Infrastructure.AccountServices.Models.Responses;

public class CurrentAccountTransactionResponse
{
    public AccountBalanceResponse WalletBalance { get; set; }
    public AccountBalanceResponse CreditBalance { get; set; }
    public decimal TotalCashIn { get; set; }
    public decimal TotalCashOut { get; set; }
    public decimal TotalBetAmount { get; set; }
    public int TotalCashInCount { get; set; }
    public int TotalCashOutCount { get; set; }
    public DateTime Date { get; set; }
}
