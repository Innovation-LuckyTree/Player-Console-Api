namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Limits;

public class AdminExclusionResponse
{
    public int AdministrativeExclusionId { get; set; }
    public long AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TimeDurationStr { get; set; }
    public DateTime DateExpiry { get; set; }
    public TimeSpan TimeDuration { get; set; }
    public int DayDuration { get; set; }
    public int Status { get; set; }
    public string TimeLeft { get; set; }
    public string GameType { get; set; }
    public DateTime CreatedOn { get; set; }
    public string FullName { get; set; }
    public bool IsAdminExcluded
    {
        get
        {
            return DateExpiry > DateTime.Now;
        }
    }
}