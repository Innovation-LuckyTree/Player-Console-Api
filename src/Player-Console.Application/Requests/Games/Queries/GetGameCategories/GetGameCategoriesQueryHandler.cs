using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetGameCategories;

public class GetGameCategoriesQueryHandler(ICoreApi coreApi) : IRequestHandler<GetGameCategoriesQuery, object>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<object> Handle(GetGameCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _coreApi.GetGameCategories(cancellationToken);
    }
}