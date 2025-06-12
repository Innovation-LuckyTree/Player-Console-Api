namespace HP_Player_Console.Infrastructure.AccountServices.Models.Requests;

public class TransferAssetRequest
{
    public Guid AccountWalletId { get; set; }
    public Guid AccountCreditId { get; set; }
    public decimal Amount { get; set; }
    public string Notes { get; set; }

    public string ModeOfTransaction { get; set; } = "Happy Play App";

    public string TransactionNo
    {
        get
        {
            var transaction = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            return transaction[..15];
        }
    }
}