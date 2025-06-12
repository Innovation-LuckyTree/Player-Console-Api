using HP_Player_Console.Application.Common.Constants;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetUserToken;

public class GetAuthTokenQueryHandler(ICoreAccountApi coreAccountApi, ICoreIdentityApi coreIdentityApi) : IRequestHandler<GetAuthTokenQuery, LoginUserResponse>
{
    private const int _completeStatus = 7;
    private const int _noOfSecondsForVerification = 25920000;
    private readonly ICoreIdentityApi _coreIdentityApi = coreIdentityApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<LoginUserResponse> Handle(GetAuthTokenQuery request, CancellationToken cancellationToken)
    {
        var loginResponse = await _coreIdentityApi.LoginUser(request.UserName, request.Password, request.IpAddress, cancellationToken);
        if (!loginResponse.Success)
            return loginResponse;

        var coreAccount = await _coreAccountApi.FindPlayer(new FindPlayerRequest(loginResponse.Data.Id, loginResponse.Data.CompanyId), cancellationToken);

        if (coreAccount == null)
            return new LoginUserResponse { Success = false, ResponseCode = LoginExceptionCodes.INVALID_USER_TYPE, ErrorMessage = "Invalid user type!" };

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

        return loginResponse;
    }
}