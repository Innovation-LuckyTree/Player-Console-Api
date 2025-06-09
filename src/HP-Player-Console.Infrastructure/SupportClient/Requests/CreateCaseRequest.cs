namespace HP_Player_Console.Infrastructure.Support.Requests;

public class CreateCaseRequest
{
    public Owner Owner { get; set; }
    public Owner? AssignTo { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? CategoryId { get; set; }
    public int? OrganizationId { get; set; }
    public int? TicketStatus { get; set; }
    public Guid? CompanyId { get; set; }
    public PriorityLevels PriorityLevel { get; set; }
    public int? BranchId { get; set; }
    public DateTime TicketDate { get; set; }
    public string? Comment { get; set; }
    public List<Attachment> Attachments { get; set; }
}

public class Owner
{
    public string UserId { get; set; }
    public string MobileNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
}

public class Attachment
{
    public string FileName { get; set; }
    public string? Content { get; set; }
    public string? FileType { get; set; }
}
public enum PriorityLevels
{
    Low,
    High,
    Critical
}
