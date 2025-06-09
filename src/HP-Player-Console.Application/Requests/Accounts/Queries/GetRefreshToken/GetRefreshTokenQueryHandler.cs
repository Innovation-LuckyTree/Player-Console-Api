using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetRefreshToken;

public class GetRefreshTokenQueryHandler(ICoreIdentityApi coreIdentityApi) : IRequestHandler<GetRefreshTokenQuery, LoginUserResponse>
{
    private readonly ICoreIdentityApi _coreIdentityApi = coreIdentityApi;

    public async Task<LoginUserResponse> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var tokenResponse = await _coreIdentityApi.GetRefreshToken(request.Token, request.RefreshToken, cancellationToken);

        return tokenResponse;
    }
}