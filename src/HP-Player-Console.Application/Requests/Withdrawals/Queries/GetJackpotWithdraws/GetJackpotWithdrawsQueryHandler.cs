using HP_Player_Console.Common.Models;
using HP_Player_Console.Infrastructure.Core.Models.Requests.JackpotWinners;
using HP_Player_Console.Infrastructure.Core.Models.Responses.JackpotWinners;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetJackpotWithdraws;

public class GetJackpotWithdrawsQueryHandler(ICoreApi coreApi) : IRequestHandler<GetJackpotWithdrawsQuery, JackpotWinnersInfoVmResponse>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<JackpotWinnersInfoVmResponse> Handle(GetJackpotWithdrawsQuery request, CancellationToken cancellationToken)
    {
        PagedQuery pagedQuery = new();

        var jackpotWinRequest = new GetCurrentAccountJackpotWinRequest(null, pagedQuery);

        return await _coreApi.GetCurrentAccountJackpotWin(jackpotWinRequest, cancellationToken);
    }
}