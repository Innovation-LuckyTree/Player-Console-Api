using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGameProviderList;

public class GetGameProviderListQueryHandler(ICoreApi coreApi) : IRequestHandler<GetGameProviderListQuery, object>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<object> Handle(GetGameProviderListQuery request, CancellationToken cancellationToken)
    {
        return await _coreApi.GetProviderByCategoryId(request.CategoryId, cancellationToken);
    }
}
