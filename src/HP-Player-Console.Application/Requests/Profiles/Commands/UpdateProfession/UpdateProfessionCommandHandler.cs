using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProfessionCommand;

public class UpdateProfessionCommandHandler : IRequestHandler<UpdateProfessionCommand, object>
{
    private readonly ICoreApi _coreApi;

    public UpdateProfessionCommandHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<object> Handle(UpdateProfessionCommand request, CancellationToken cancellationToken)
    {
        return await _coreApi.UpdateProfession(request.Data, cancellationToken);
    }
}