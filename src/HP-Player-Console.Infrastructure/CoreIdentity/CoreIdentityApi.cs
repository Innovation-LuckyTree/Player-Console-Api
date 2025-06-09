using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Requests;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using System.Net;
using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.CoreIdentity;

public class CoreIdentityApi : AbstractApiClient, ICoreIdentityApi
{
    private readonly string _clientId;

    public CoreIdentityApi(HttpClient? client, IAppConfig appConfig) : base(nameof(CoreIdentityApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.CoreIdentityApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.CoreIdentityApiClient.Resource);

        _clientId = appConfig.AppId;
    }

    public async Task<LoginUserResponse> LoginUser(string userName, string password, string ipAddress, CancellationToken cancellationToken)
    {
        var loginRequest = new LoginUserRequest
        {
            UserName = userName,
            Password = password,
            TenantId = _clientId,
            IpAddress = ipAddress
        };

        var response = await _client.PostAsJsonAsync("api/auth/account/login", loginRequest, cancellationToken);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errContent = await response.Content.ReadFromJsonAsync<BadRequestResponse>(cancellationToken);
            return new LoginUserResponse { Success = false, ResponseCode = "001", ErrorMessage = errContent.Detail };
        }

        if (!response.IsSuccessStatusCode)
            return new LoginUserResponse { Success = false, ResponseCode = "001", ErrorMessage = "Unable to login user account!" };

        var content = await response.Content.ReadFromJsonAsync<UserLoginInfo>();

        if (content.IsLocked)
            return new LoginUserResponse { Success = false, ResponseCode = "005", ErrorMessage = "User account is lock! please try again later" };

        return new LoginUserResponse { Data = content };
    }

    public async Task<LoginUserResponse> LoginUserByTokenDevice(AuthDeviceTokenRequest request, CancellationToken cancellationToken)
    {
        request.TenantId = _clientId;

        var response = await _client.PostAsJsonAsync("/api/auth/device", request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errContent = await response.Content.ReadFromJsonAsync<BadRequestResponse>(cancellationToken);
            return new LoginUserResponse { Success = false, ResponseCode = "003", ErrorMessage = errContent.Detail };
        }

        if (!response.IsSuccessStatusCode)
            return new LoginUserResponse { Success = false, ResponseCode = "003", ErrorMessage = "Failed to process Refresh Token" };

        var content = await response.Content.ReadFromJsonAsync<UserLoginInfo>();
        return new LoginUserResponse { Data = content };
    }

    public async Task<LoginUserResponse> GetRefreshToken(string token, string refreshToken, CancellationToken cancellationToken)
    {
        var request = new RefreshTokenRequest(token, refreshToken);

        var response = await _client.PostAsJsonAsync("api/auth/token/refresh", request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errContent = await response.Content.ReadFromJsonAsync<BadRequestResponse>(cancellationToken);
            return new LoginUserResponse { Success = false, ResponseCode = "002", ErrorMessage = errContent.Detail };
        }

        if (!response.IsSuccessStatusCode)
            return new LoginUserResponse { Success = false, ResponseCode = "002", ErrorMessage = "Failed to process Refresh Token" };

        var content = await response.Content.ReadFromJsonAsync<UserLoginInfo>(cancellationToken);
        return new LoginUserResponse { Data = content };
    }

    public async Task<UserDeviceTokenResponse> CreateUserDeviceToken(CreateUserDeviceTokenRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/userDeviceToken", request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errContent = await response.Content.ReadFromJsonAsync<BadRequestResponse>(cancellationToken);
            return new UserDeviceTokenResponse { Success = false, ResponseCode = "002", ErrorMessage = errContent.Detail };
        }

        if (!response.IsSuccessStatusCode)
            return new UserDeviceTokenResponse { Success = false, ResponseCode = "002", ErrorMessage = "Failed to process Refresh Token" };

        var content = await response.Content.ReadFromJsonAsync<UserDeviceTokenInfo>();
        return new UserDeviceTokenResponse { Data = content! };
    }
}