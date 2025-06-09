using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using MediatR;

namespace HP_Player_Console.Application.Requests.Otps.Queries.GetPendingOtp;

public class GetPendingOtpQuery : IRequest<OtpDataResponse>
{
}

