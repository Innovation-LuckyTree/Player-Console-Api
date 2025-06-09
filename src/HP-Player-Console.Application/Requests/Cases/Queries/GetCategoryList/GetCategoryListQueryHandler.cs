using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.GetCategoryList;

public class GetCategoryListQueryHandler(ISupportClientApi supportApi) : IRequestHandler<GetCategoryListQuery, object>
{
    private readonly ISupportClientApi _supportApi = supportApi;

    public async Task<object> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        return await _supportApi.GetCategoryList(cancellationToken);
    }
}
