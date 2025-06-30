namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class CurrentAccountResponse
{
    public long AccountInfoId { get; set; }
    public Guid AccountObjectId { get; set; }
    public Guid AccountCreditId { get; set; }
    public Guid AccountBonusId { get; set; }
    public Guid UserId { get; set; }
    public string PaymentAccount { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Suffix { get; set; }
    public int? SalaryRange { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string NatureOfWork { get; set; }
    public string SourceOfIncome { get; set; }
    public string FrontIdPath { get; set; }
    public string BackIdPath { get; set; }
    public string SignaturePath { get; set; }
    public string ProfilePath { get; set; }
    public string SelfiePath { get; set; }
    public string FullName { get; set; }
    public bool IsVerified { get; set; }
    public bool IsDeclined { get; set; }
    public bool ForVerification { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string BranchAddress { get; set; }
    public string BirthDate { get; set; }
    public DateTime LastPasswordChange { get; set; } = DateTime.Now;
    public DateTimeOffset DateCreated { get; set; }
}
