using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

namespace HP_Player_Console.Infrastructure.PaymentServices.Models;

public class PaymentAccount
{
    public PaymentAccount()
    {
    }

    public PaymentAccount(PaymentAccountInfo account)
    {
        AccountObjId = account.AccountObjId;
        AccountName = account.AccountName;
    }

    public Guid AccountObjId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public int AccountType { get; set; }
}
