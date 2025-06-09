using HP_Player_Console.Application.Common.Constants;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Requests;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetAuthByTokenDevice;

public class GetAuthByTokenDeviceQueryHandler(ICoreApi coreApi, ICoreIdentityApi coreIdentityApi) : IRequestHandler<GetAuthByTokenDeviceQuery, LoginUserResponse>
{
    private const int _completeStatus = 7;
    private const int _noOfSecondsForVerification = 25920000;
    private readonly ICoreApi _coreApi = coreApi;
    private readonly ICoreIdentityApi _coreIdentityApi = coreIdentityApi;

    public async Task<LoginUserResponse> Handle(GetAuthByTokenDeviceQuery request, CancellationToken cancellationToken)
    {
        var tokenRequest = new AuthDeviceTokenRequest(request.UserId, request.TokenId, request.Key, request.IpAddress);

        var userTokenResponse = await _coreIdentityApi.LoginUserByTokenDevice(tokenRequest, cancellationToken);
        var coreAccount = await _coreApi.FindPlayer(new FindPlayerRequest(userTokenResponse.Data.Id, userTokenResponse.Data.CompanyId), cancellationToken);

        if (coreAccount == null)
        {
            return new LoginUserResponse { Success = false, ResponseCode = LoginExceptionCodes.INVALID_USER_TYPE, ErrorMessage = "Invalid user type!" };
        }

        if (coreAccount.AccountStatus != _completeStatus)
            return new LoginUserResponse { Success = false, ResponseCode = LoginExceptionCodes.INVALID_CREDENTIAL, ErrorMessage = "Unable to login user account!" };

        var daysVerified = DateTime.Now.Subtract(coreAccount.CreatedOn).TotalSeconds;

        if (!coreAccount.IsVerified && daysVerified > _noOfSecondsForVerification)
        {
            return new LoginUserResponse
            {
                Success = false,
                ResponseCode = LoginExceptionCodes.UNVERIFIED_ACCOUNT,
                ErrorMessage = "Your account has been suspended due to inactivity. Please verify your account to reactivate",
                Data = new UserLoginInfo
                {
                    AccountId = coreAccount.AccountId
                }
            };
        }

        return userTokenResponse;
    }
}