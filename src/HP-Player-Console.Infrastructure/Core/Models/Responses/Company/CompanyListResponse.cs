namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Company;

public class CompanyListResponse
{
    public int Total { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public List<CompanyListDto> CompanyList { get; set; }
}

public class CompanyListDto
{
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; }
    public bool IsActive { get; set; }
    public int? NumberOfBranch { get; set; }
    public int? NumberOfOperator { get; set; }
    public string BranchOperator { get; set; }
    public string BranchContact { get; set; }
    public string MainBranch { get; set; }
    public DateTime CreatedOn { get; set; }
}
