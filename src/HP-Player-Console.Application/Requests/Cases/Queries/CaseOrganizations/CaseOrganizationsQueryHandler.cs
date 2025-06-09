using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.CaseOrganizations;

public class CaseOrganizationsQueryHandler(ISupportClientApi supportApi) : IRequestHandler<CaseOrganizationsQuery, object>
{
    private readonly ISupportClientApi _supportApi = supportApi;

    public async Task<object> Handle(CaseOrganizationsQuery request, CancellationToken cancellationToken)
    {
        return await _supportApi.GetCaseOrganizations(cancellationToken);
    }
}
