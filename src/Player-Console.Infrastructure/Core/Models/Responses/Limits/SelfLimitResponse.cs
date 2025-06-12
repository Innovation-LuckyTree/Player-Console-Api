namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Limits;

public class SelfLimitResponse
{
    public int SelfLimitId { get; set; }
    public long AccountId { get; set; }
    public decimal AmountLimit { get; set; }
    public int Status { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public TimeSpan TimeDuration { get; set; }
    public DateTime CreatedOn { get; set; }
    public string FullName { get; set; }
}