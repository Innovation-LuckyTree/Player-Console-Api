using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;

public class AccountBonusRequest
{
    public long AccountId { get; set; }
    public PagedQuery PagedQuery { get; set; }
}
