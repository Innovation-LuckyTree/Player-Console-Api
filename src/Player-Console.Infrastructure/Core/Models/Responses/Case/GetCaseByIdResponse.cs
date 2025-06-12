namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Case;

public class CaseDto
{
    public long CaseId { get; set; }
    public string Fullname { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long CaseOwnerId { get; set; }
    public int CategoryId { get; set; }
    public int OrganizationId { get; set; }
    public int StatusId { get; set; }
    public bool Internal { get; set; }
    public int Importance { get; set; }
    public string Remarks { get; set; }
    public long? ReportedPersonId { get; set; }
    public string Category { get; set; }
    public string Organization { get; set; }
    public string Status { get; set; }
    public int AttachmentCount { get; set; }
    public IEnumerable<CommentDto>? Comments { get; set; }
    public DateTime TicketDate { get; set; }
    public IEnumerable<CaseAttachment> Attachments { get; set; }

    public AccountDto CaseOwner { get; set; }
    public AccountDto ReportedPerson { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedBy { get; set; }
}

public partial class CaseAttachment
{
    public int CaseAttachmentId { get; set; }
    public long CaseId { get; set; }
    public string FileName { get; set; }
    public byte[]? Content { get; set; } = null;
    public string? FileType { get; set; }
}

public class AccountDto
{
    public long AccountId { get; set; }
    public string UserId { get; set; }
    public string MobileNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }

    public string FullName { get; set; }
}

public class CommentDto
{
    public long CaseCommentId { get; set; }
    public long CaseId { get; set; }
    public string Comment { get; set; }
    public long AccountId { get; set; }
    public int Status { get; set; } = 0;
    public DateTime CreatedOn { get; set; }
    public IEnumerable<CommentAttachment> CommentAttachments { get; set; }
}
public partial class CommentAttachment
{
    public long CommentAttachmentId { get; set; }
    public long CaseCommentId { get; set; }
    public string FileName { get; set; }
    public byte[]? Content { get; set; }
    public string? FileType { get; set; }
}

