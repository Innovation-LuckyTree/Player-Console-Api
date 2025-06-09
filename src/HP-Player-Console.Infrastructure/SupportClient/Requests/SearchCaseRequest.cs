namespace HP_Player_Console.Infrastructure.Support.Requests
{
    public class SearchCaseRequest
    {
        public string CaseId { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string Owner { get; set; } = "";
        public int? Status { get; set; }
        public int? Importance { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CasePagedQuery PagedQuery { get; set; }
    }

    public class CasePagedQuery
    {
        public int Index { get; set; } = 0;
        public int Size { get; set; } = 1000;
    }
}
