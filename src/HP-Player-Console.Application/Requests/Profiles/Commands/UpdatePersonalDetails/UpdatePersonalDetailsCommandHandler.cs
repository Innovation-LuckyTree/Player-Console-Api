using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdatePersonalDetails;

public class UpdatePersonalDetailsCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<UpdatePersonalDetailsCommand, object>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(UpdatePersonalDetailsCommand request, CancellationToken cancellationToken)
    {
        return await _coreAccountApi.UpdatePersonalDetails(request.Data, cancellationToken);
    }
}