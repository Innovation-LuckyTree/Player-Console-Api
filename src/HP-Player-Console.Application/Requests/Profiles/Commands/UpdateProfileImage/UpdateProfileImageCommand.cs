using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProfileImage;

public class UpdateProfileImageCommand : IRequest<object>
{
    public UpdateProfileImageRequest Data { get; set; }
}

public class UpdateProfileImageCommandHandler : IRequestHandler<UpdateProfileImageCommand, object>
{
    private readonly ICoreApi _coreApi;

    public UpdateProfileImageCommandHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<object> Handle(UpdateProfileImageCommand request, CancellationToken cancellationToken)
    {
        return await _coreApi.UpdateProfileImage(request.Data, cancellationToken);
    }
}