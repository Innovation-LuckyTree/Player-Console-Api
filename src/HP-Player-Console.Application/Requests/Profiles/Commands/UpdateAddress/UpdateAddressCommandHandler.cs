using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateAddress;

public class UpdateAddressCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<UpdateAddressCommand, object>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        return await _coreAccountApi.UpdateAddress(request.Data, cancellationToken);
    }
}