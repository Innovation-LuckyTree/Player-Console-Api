using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdatePersonalDetails;

public class UpdatePersonalDetailsCommandHandler : IRequestHandler<UpdatePersonalDetailsCommand, object>
{
    private readonly ICoreApi _coreApi;

    public UpdatePersonalDetailsCommandHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<object> Handle(UpdatePersonalDetailsCommand request, CancellationToken cancellationToken)
    {
        return await _coreApi.UpdatePersonalDetails(request.Data, cancellationToken);
    }
}