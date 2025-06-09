using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.SelfExclusion.Queries.GetActiveExclusion;

public class GetActiveExclusionQueryHandler : IRequestHandler<GetActiveExclusionQuery, SelfExclusionVmResponse>
{
    private readonly ICoreApi _coreApi;

    public GetActiveExclusionQueryHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<SelfExclusionVmResponse> Handle(GetActiveExclusionQuery request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreApi.AccountCurrent(cancellationToken);
        return await _coreApi.GetActiveExlusion(accountInfo.AccountInfoId, cancellationToken);
    }
}
