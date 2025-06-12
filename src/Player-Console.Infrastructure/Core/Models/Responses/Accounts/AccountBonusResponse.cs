using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class AccountBonusResponse : ApiBaseResponse<AccountBonusVm>
{
}

public class AccountBonusVm
{
    public int Total { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public List<AccountBonusInfo> AccoutBonuses { get; set; }

}

public class AccountBonusInfo
{
    public long AccountBonusId { get; set; }
    public string FullName { get; set; }
    public string UserType { get; set; }
    public long PromotionId { get; set; }
    public string PromotionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal BonusAmount { get; set; }
    public int Status { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsReturn { get; set; } = false;
    public DateTime? ReturnDate { get; set; }

}