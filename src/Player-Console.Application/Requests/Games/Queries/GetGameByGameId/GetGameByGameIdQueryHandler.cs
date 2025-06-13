using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGameByGameId;

public class GetGameByGameIdQueryHandler(IHuiduClientApi huiduClientApi) : IRequestHandler<GetGameByGameIdQuery, string>
{
    private readonly IHuiduClientApi _huiduClientApi = huiduClientApi;

    public async Task<string> Handle(GetGameByGameIdQuery request, CancellationToken cancellationToken)
    {
        return await _huiduClientApi.GetGame("h6e466ABC", request.GameId, "100.00", cancellationToken);
    }
}