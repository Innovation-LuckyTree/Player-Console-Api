using HP_Player_Console.Common.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetBonusHistory;

public record GetBonusHistoryQuery(int? TransactionType, DateTime? StartDate, DateTime? EndDate, PagedQuery PagedQuery) : IRequest<BonusAccountDto>;
