using HP_Player_Console.Application.Common.Exceptions;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProofInfo;

public class UpdateProofInfoCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<UpdateProofInfoCommand, object>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(UpdateProofInfoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _coreAccountApi.UpdateProofInfo(request.Data, cancellationToken);
        }
        catch(Exception ex)
        {
            throw new BadRequestBaseException(ex.Message)
            {
                ErrorCode = "400",
            };
        }

    }
}