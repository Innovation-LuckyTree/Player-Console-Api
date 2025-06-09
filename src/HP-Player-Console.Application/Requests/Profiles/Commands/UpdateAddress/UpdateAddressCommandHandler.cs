using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, object>
{
    private readonly ICoreApi _coreApi;

    public UpdateAddressCommandHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<object> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        return await _coreApi.UpdateAddress(request.Data, cancellationToken);
    }
}