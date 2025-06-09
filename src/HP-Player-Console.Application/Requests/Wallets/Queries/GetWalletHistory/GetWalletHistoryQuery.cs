using HP_Player_Console.Common.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetWalletHistory;

public record GetWalletHistoryQuery(int? TransactionType, DateTime? StartDate, DateTime? EndDate, PagedQuery PagedQuery) : IRequest<AccountDto>;
