using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.SelfExclusion.Commands.CreateNewExclusion;

public class CreateNewExclusionCommandHandler : IRequestHandler<CreateNewExclusionCommand, SelfExclusionVmResponse>
{
    private readonly ICoreApi _coreApi;

    public CreateNewExclusionCommandHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<SelfExclusionVmResponse> Handle(CreateNewExclusionCommand request, CancellationToken cancellationToken)
    {
        return await _coreApi.CreateSelfExclusion(request.request, cancellationToken);
    }
}
