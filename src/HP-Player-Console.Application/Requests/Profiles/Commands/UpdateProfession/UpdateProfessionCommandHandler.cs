using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProfessionCommand;

public class UpdateProfessionCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<UpdateProfessionCommand, object>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(UpdateProfessionCommand request, CancellationToken cancellationToken)
    {
        return await _coreAccountApi.UpdateProfession(request.Data, cancellationToken);
    }
}