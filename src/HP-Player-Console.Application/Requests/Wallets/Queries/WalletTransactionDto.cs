namespace HP_Player_Console.Application.Requests.Wallets.Queries;

public class WalletTransactionDto
{
    public Guid Id { get; set; }
    public string TransactionType { get; set; }
    public string TransactionNo { get; set; }
    public string TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public decimal CreditResult { get; set; }
    public decimal WalletResult { get; set; }
    public string Notes { get; set; }
    public bool IsTransfer { get; set; }

    public string Mode
    {
        get
        {
            if (IsTransfer)
            {
                return "App";
            }

            if (TransactionType == "CASH-IN")
            {
                if (Notes.Equals("CREDIT-LOAD", StringComparison.OrdinalIgnoreCase))
                    return "Loading Network";

                if (Notes.Equals("ON-SITE, CASH-DEPOSIT", StringComparison.OrdinalIgnoreCase))
                    return "Over the Counter";

                return "QR Cash-in";
            }

            if (!string.IsNullOrEmpty(Notes) && Notes.Equals("CASH-WITHDRAWAL", StringComparison.OrdinalIgnoreCase))
                return "Over the Counter";

            if (!string.IsNullOrEmpty(Notes) && Notes.Equals("WITHDRAW", StringComparison.OrdinalIgnoreCase))
                return "Loading Station";

            return "GCash";
        }
    }
}
