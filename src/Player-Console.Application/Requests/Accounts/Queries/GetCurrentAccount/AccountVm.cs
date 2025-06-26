using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetCurrentAccount;

public record AccountVm(CurrentAccountResponse AccountInfo, AccountBalanceResponse AccountCredits, AccountBonusDetail BonusAccount)
{
    public decimal TotalCredits
    {
        get
        {
            decimal total = 0;

            if (AccountCredits != null)
            {
                total += AccountCredits.Balance;
            }

            if (BonusAccount != null)
            {
                total += BonusAccount.Balance;
            }

            return total;
        }
    }
}
