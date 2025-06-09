using HP_Player_Console.Application.Common.Constants;
using HP_Player_Console.Application.Common.Exceptions;
using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HP_Player_Console.Application.Requests.Otps.Commands.GenerateOtp;

public class GenerateOtpCommandHandler(ICoreAccountApi coreAccountApi, ILogger<GenerateOtpCommandHandler> logger) : IRequestHandler<GenerateOtpCommand, OtpResponse>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;
    private readonly ILogger<GenerateOtpCommandHandler> _logger = logger;

    public async Task<OtpResponse> Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _coreAccountApi.GenerateOTP(request.MobileNumber, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in generating OTP");

            throw new BadRequestBaseException("Unable to generate OTP as for the moment")
            {
                ErrorCode = OtpExceptionCodes.UNABLE_GENERATE_OTP
            };
        }
    }
}