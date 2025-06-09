namespace HP_Player_Console.Infrastructure.Support.Requests
{
    public class UpdateCaseOwnerRquest
    {
        public long CaseId { get; set; }
        public Owner Who { get; set; }
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
}
