using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using MediatR;

namespace HP_Player_Console.Application.Requests.Otps.Commands.GenerateOtp;

public class GenerateOtpCommand : IRequest<OtpResponse>
{
    public string MobileNumber { get; set; }
}
