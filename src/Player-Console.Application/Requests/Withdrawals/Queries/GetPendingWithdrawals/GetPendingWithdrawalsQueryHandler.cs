// using HP_Player_Console.Application.Common.Constants;
// using HP_Player_Console.Common.Models;
// using HP_Player_Console.Infrastructure.Core.Models.Requests.JackpotWinners;
// using HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;
// using HP_Player_Console.Infrastructure.Interfaces;
// using MediatR;

// namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetPendingWithdrawals;

// public class GetPendingWithdrawalsQueryHandler(ICoreApi coreApi) : IRequestHandler<GetPendingWithdrawalsQuery, PendingWithdrawalVm>
// {
//     private readonly ICoreApi _coreApi = coreApi;

//     public async Task<PendingWithdrawalVm> Handle(GetPendingWithdrawalsQuery request, CancellationToken cancellationToken)
//     {
//         PagedQuery pagedQuery = new();

//         var accountInfo = await _coreApi.AccountCurrent(cancellationToken);

//         var jackpotWinRequest = new GetCurrentAccountJackpotWinRequest(JackpotWinnerStatuses.PENDING, pagedQuery);
//         var withdrawalsRequest = new GetCurrentAccountWithdrawalsRequest(WithdrawalTransactionStatuses.PENDING, pagedQuery);

//         var jackpotWinResults = await _coreApi.GetCurrentAccountJackpotWin(jackpotWinRequest, cancellationToken);
//         var withdrawalsResults = await _coreApi.GetCurrentAccountWithdrawals(withdrawalsRequest, cancellationToken);

//         var pendingJackpots = jackpotWinResults.JackpotWins.Select(o => new JackpotWinWithdrawal(o));
//         var pendingWithdrawals = withdrawalsResults.Withdrawals.Select(o => new AccounBalanceWithdrawal(o, accountInfo));

//         return new PendingWithdrawalVm(pendingJackpots, pendingWithdrawals);
//     }
// }
