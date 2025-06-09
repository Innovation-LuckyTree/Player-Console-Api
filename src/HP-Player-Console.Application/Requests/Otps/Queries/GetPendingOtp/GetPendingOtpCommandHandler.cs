using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Otps.Queries.GetPendingOtp;

public class GetPendingOtpQueryHandler : IRequestHandler<GetPendingOtpQuery, OtpDataResponse>
{
    private readonly ICoreApi _coreApi;

    public GetPendingOtpQueryHandler(ICoreApi coreApi)
    {
        _coreApi = coreApi;
    }

    public async Task<OtpDataResponse> Handle(GetPendingOtpQuery request, CancellationToken cancellationToken)
    {
        var result = await _coreApi.GetPendingOtp(cancellationToken);

        return result;
    }
}

