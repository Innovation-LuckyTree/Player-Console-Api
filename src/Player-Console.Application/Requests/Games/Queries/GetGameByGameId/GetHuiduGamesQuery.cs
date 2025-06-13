using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGameByGameId;

public record GetGameByGameIdQuery(string GameId) : IRequest<string>;
