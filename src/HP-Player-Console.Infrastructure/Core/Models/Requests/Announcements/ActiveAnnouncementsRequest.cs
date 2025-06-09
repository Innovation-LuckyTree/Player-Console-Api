namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Announcements;

public record ActiveAnnouncementsRequest
{
  public int CompanyId { get; set; }
  public int BranchId { get; set; }
}
