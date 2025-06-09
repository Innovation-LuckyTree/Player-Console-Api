using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetCurrentAccount;

public record AccountVm(CurrentAccountResponse AccountInfo, AccountBalanceResponse AccountWallet, AccountBalanceResponse AccountCredits, AccountBonusDetail BonusAccount);
