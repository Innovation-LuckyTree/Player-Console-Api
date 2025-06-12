
namespace HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
public class SelfExclusionVmResponse
{
    public int SelfExclusionId { get; set; }
    public long AccountId { get; set; }
    public bool IsIndefinite { get; set; } = false;
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int? Status { get; set; }

}