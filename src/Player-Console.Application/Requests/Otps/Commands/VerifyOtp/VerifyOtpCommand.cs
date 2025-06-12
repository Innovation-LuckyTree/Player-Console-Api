using MediatR;

namespace HP_Player_Console.Application.Requests.Otps.Commands.VerifyOtp;

public record VerifyOtpCommand(long ReferenceId, string MobileNumber, string OtpCode) : IRequest<Unit>
{
}
