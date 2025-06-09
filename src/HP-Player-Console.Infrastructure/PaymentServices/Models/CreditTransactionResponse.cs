using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.PaymentServices.Models;

public class CreditTransactionResponse : ApiResponseBase<CreditTransactionList>
{
}

public class CreditTransactionList
{
    public int Total { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public List<CreditTransactionInfo> Transactions { get; set; }
}