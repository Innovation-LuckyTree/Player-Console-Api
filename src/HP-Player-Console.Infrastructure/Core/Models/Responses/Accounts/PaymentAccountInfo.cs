namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class PaymentAccountInfo
{
    public long AccountId { get; set; }
    public Guid AccountObjId { get; set; }
    public string AccountName { get; set; }
    public string AccountType { get; set; }
    public string ReferralKey { get; set; }
}