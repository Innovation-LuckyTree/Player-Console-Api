using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGamesByProviderAndCategory;

public record GetGamesByProviderAndCategoryQuery(int CategoryId, int ProviderId, int PageNumber, int PageSize) : IRequest<object>;
