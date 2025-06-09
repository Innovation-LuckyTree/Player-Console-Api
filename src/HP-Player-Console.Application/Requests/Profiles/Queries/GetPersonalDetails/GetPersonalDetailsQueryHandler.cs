namespace HP_Player_Console.Requests.Profiles.Queries.GetPersonalDetails;

using System.Threading;
using System.Threading.Tasks;
using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Profiles;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

public class GetPersonalDetailsQueryHandler(ICoreAccountApi coreAccountApi, ICurrentUserService currentUserService) : IRequestHandler<GetPersonalDetailsQuery, UserDetailsResponse>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<UserDetailsResponse> Handle(GetPersonalDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _coreAccountApi.GetUserById(_currentUserService.UserObjId, cancellationToken);

        return result;
    }
}