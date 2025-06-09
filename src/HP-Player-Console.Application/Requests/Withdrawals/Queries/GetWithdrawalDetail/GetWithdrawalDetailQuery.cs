using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetWithdrawalDetail;

public record GetWithdrawalDetailQuery(long TransactionId) : IRequest<object>;
