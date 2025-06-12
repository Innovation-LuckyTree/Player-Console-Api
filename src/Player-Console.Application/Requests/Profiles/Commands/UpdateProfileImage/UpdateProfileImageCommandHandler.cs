using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProfileImage;

public class UpdateProfileImageCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<UpdateProfileImageCommand, object>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(UpdateProfileImageCommand request, CancellationToken cancellationToken)
    {
        return await _coreAccountApi.UpdateProfileImage(request.Data, cancellationToken);
    }
}