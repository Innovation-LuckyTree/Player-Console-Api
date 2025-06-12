namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetBonusHistory;

public class BonusAccountTransactionDto
{
    public Guid Id { get; set; }
    public string TransactionNo { get; set; }
    public int TransactionType { get; set; }
    public string TransactionReference { get; set; }
    public decimal Amount { get; set; }
    public decimal Credit { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Notes { get; set; }
    public decimal StartAmount
    {
        get
        {
            return Credit - Amount;
        }
    }
    public string TransactionName
    {
        get
        {
            if (TransactionReference.Contains("ACCOUNT-BET"))
            {
                return "Bet";
            }

            if (TransactionType == 0)
            {
                return "Recieve";
            }

            if (Notes.Contains("Win"))
            {
                return "Win";
            }

            return "";
        }
    }

    public string Type
    {
        get
        {
            return TransactionType == 0 ? "Debit" : "Credit";
        }
    }
}
