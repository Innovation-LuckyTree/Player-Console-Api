namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class FindPlayerResponse
{
    public Guid UserId { get; set; }
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public int AccountStatus { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedOn { get; set; }
}
