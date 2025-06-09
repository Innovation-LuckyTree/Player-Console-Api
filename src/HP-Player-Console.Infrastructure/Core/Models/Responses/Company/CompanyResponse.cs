namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Company;

public class CompanyResponse
{
    public int CompanyId { get; set; }
    public Guid CompanyObjectId { get; set; }
    public string CompanyName { get; set; }
    public decimal WithdrawalLimit { get; set; }
    public bool IsActive { get; set; }
    public int? NumberOfBranch { get; set; }
    public int? DashboardUserCount { get; set; }
    public int? AcountingUserCount { get; set; }
    public int? SupportUserCount { get; set; }

    public string? Address { get; set; }
    public DateTime CreatedOn { get; set; }
}
