using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.CaseStatuses;

public class GetCaseStatusesQueryHandler(ISupportClientApi supportApi) : IRequestHandler<GetCaseStatusesQuery, object>
{
    private readonly ISupportClientApi _supportApi = supportApi;

    public async Task<object> Handle(GetCaseStatusesQuery request, CancellationToken cancellationToken)
    {
        return await _supportApi.GetCaseStatuses(cancellationToken);
    }
}
