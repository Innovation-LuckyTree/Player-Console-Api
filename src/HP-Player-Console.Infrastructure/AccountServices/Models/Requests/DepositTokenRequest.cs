namespace HP_Player_Console.Infrastructure.AccountServices.Models.Requests;

public class DepositTokenRequest
{
    public string MerchantName { get; set; }
    public string AccountId { get; set; }
    public decimal Amount { get; set; }
    public string AccountName { get; set; }
    public string TransactionType { get; set; }
    public string TransactionId { get; set; } = "";

}