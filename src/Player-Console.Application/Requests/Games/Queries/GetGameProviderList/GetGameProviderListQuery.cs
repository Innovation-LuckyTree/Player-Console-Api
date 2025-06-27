using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGameProviderList;

public record GetGameProviderListQuery(int CategoryId, bool IsFavorite) : IRequest<object>;
