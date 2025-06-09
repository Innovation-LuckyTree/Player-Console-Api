namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class PlayersAgentResponse
{
    public PaymentAccountInfo Agent { get; set; }
    public PaymentAccountInfo Player { get; set; }
    public string CompanyName { get; set; }
    public string BranchName { get; set; }
}
