
namespace HP_Player_Console.Infrastructure.Core.Models.Requests.SelfExclusion;
public class SelfExclusionRequest
{
    public long AccountId { get; set; }
    public int SelfExclusionId { get; set; }
    public bool IsIndefinite { get; set; } = false;
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int? Status { get; set; } = 1;

}