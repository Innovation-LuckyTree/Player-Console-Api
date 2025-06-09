namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetPendingWithdrawals;

public record PendingWithdrawalVm(IEnumerable<JackpotWinWithdrawal> JackpotWins, IEnumerable<AccounBalanceWithdrawal> AccountBalance);
