using HP_Player_Console.Infrastructure.Core.Models.Responses.JackpotWinners;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetJackpotWithdraws;

public class GetJackpotWithdrawsQuery : IRequest<JackpotWinnersInfoVmResponse>
{
}
