using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<UpdateUserPasswordCommand, Unit>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<Unit> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var updateRequest = new UpdateUserPasswordRequest
        {
            UserId = request.UserId,
            MobileNumber = request.MobileNumber,
            OtpReferenceId = request.OtpReferenceId,
            NewPassword = request.NewPassword,
            ConfirmPassword = request.ConfirmPassword
        };

        await _coreAccountApi.UpdateUserPassword(updateRequest, cancellationToken);
        return Unit.Value;
    }
}
