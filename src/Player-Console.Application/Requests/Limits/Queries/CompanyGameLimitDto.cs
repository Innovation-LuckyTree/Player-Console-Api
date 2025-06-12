namespace HP_Player_Console.Application.Requests.Limits.Queries;

public class CompanyGameLimitDto
{
    public int BetEntryLimit { get; set; }
    public int MaxFavorites { get; set; }
    public int MaxDeckUnits { get; set; }
    public bool AdminExclusion { get; set; }
    public DateTime? AdminExclusionExpiry { get; set; }
    public int HotCombinationRefresh { get; set; }
    public int MaxDuplicates { get; set; }
    public int MaxPurchase { get; set; }
    public decimal? SelfLimitAmount { get; set; }
    public decimal Amount { get; set; }
    public bool isFixed { get; set; }
    public bool isActive { get; set; }
}
