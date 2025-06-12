using HP_Player_Console.Application.Common.Exceptions;
using HP_Player_Console.Infrastructure.Core.Models.Requests.OTP;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Otps.Commands.VerifyOtp;

public class VerifyOtpCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<VerifyOtpCommand, Unit>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<Unit> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var verifyRequest = new VerifyOtpRequest(request.ReferenceId, request.MobileNumber, request.OtpCode);

        var response = await _coreAccountApi.VerifyOTP(verifyRequest, cancellationToken);

        if (!response.Success)
        {
            throw new BadRequestBaseException("Code Invalid. Submit another code or Resend to get a new one.") { Data = "007" };
        }

        return Unit.Value;
    }
}