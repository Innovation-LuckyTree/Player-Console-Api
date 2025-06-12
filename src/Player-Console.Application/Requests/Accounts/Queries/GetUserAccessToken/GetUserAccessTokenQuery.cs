using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetUserAccessToken;

public class GetUserAccessTokenQuery : IRequest<UserAccessTokenResponse> { }

public class GetUserAccessTokenQueryHandler(ICoreIdentityApi coreIdentityApi, ICurrentUserService currentUserService) : IRequestHandler<GetUserAccessTokenQuery, UserAccessTokenResponse>
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly ICoreIdentityApi _coreIdentityApi = coreIdentityApi;

    public async Task<UserAccessTokenResponse> Handle(GetUserAccessTokenQuery request, CancellationToken cancellationToken)
    {

        var userId = _currentUserService.UserObjId;
        var logId = _currentUserService.LogId;

        return await _coreIdentityApi.GetUserAccessToken(userId, logId, cancellationToken);
    }
}
