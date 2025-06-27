using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGamesByProviderAndCategory;

public class GetGamesByProviderAndCategoryQueryHandler(ICoreApi coreApi) : IRequestHandler<GetGamesByProviderAndCategoryQuery, object>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<object> Handle(GetGamesByProviderAndCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _coreApi.GetGamesByCategoryAndProvider(request.CategoryId, request.ProviderId, request.PageNumber, request.PageSize, cancellationToken);
    }
}