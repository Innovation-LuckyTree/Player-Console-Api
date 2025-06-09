using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.SelfExclusion.Commands.UpdateActiveExclusion;

public class UpdateActiveExclusionCommandHandler(ICoreApi coreApi) : IRequestHandler<UpdateActiveExclusionCommand, SelfExclusionVmResponse>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<SelfExclusionVmResponse> Handle(UpdateActiveExclusionCommand request, CancellationToken cancellationToken)
    {
        return await _coreApi.UpdateActiveExclusion(request.request, cancellationToken);
    }
}
