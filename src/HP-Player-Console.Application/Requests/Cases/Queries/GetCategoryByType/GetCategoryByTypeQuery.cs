using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.GetCategoryByType;

public record GetCategoryByTypeQuery(int TypeId) : IRequest<object>;

public class GetCategoryByTypeQueryHandler(ISupportClientApi supportApi) : IRequestHandler<GetCategoryByTypeQuery, object>
{
    private readonly ISupportClientApi _supportApi = supportApi;
    
    public async Task<object> Handle(GetCategoryByTypeQuery request, CancellationToken cancellationToken)
    {
        return await _supportApi.GetCategoryByType(request.TypeId, cancellationToken);
    }
}
