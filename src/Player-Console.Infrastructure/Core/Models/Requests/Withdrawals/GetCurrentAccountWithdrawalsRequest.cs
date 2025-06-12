using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;

public record GetCurrentAccountWithdrawalsRequest(int? Status, PagedQuery PagedQuery);
