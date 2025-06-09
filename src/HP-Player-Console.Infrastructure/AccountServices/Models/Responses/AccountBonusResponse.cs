using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.AccountServices.Models.Responses;


public class AccountBonusResponse : ApiResponseBase<AccountBonusDetail>
{

}

public class AccountBonusDetail
{
    public Guid AccountId { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public IEnumerable<PromotionDetail> PromotionDetails { get; set; }
}

public class PromotionDetail
{
    public int PromotionId { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime ExpirationDate { get; set; }
    public decimal RemainingAmount { get; set; }
    public decimal ConsumedAmount { get; set; }
}