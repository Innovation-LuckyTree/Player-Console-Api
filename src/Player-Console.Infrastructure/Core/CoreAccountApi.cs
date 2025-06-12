using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Core.Models.Requests.OTP;
using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Withdrawals;
using System.Net;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Profiles;

namespace HP_Player_Console.Infrastructure.Core;

public class CoreAccountApi : AbstractApiClient, ICoreAccountApi
{
    private readonly ILogger<CoreApi> _logger;

    public CoreAccountApi(HttpClient? client, IAppConfig appConfig, ILogger<CoreApi> logger) : base(nameof(CoreApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.CoreApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.CoreApiClient.Resource);

        _logger = logger;
    }

    public async Task<CurrentAccountResponse> AccountCurrent(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/player/current", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<CurrentAccountResponse>(cancellationToken);
        return content!;
    }

    public async Task<PlayersAgentResponse> GetPlayerAgentInfo(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/player/agent-info", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<PlayersAgentResponse>(cancellationToken);
        return content!;
    }

    public async Task<FindPlayerResponse> FindPlayer(FindPlayerRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/player/find", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<FindPlayerResponse>(cancellationToken);
        return content!;
    }

    public async Task UpdateUserPassword(UpdateUserPasswordRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/account/new/password", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        response.EnsureSuccessStatusCode();
    }

    public async Task<ProviderAccountResponse> SetProviderAccount(CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/account/payment-provider", new { }, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Connecting to core api was unsuccessful.");
        }

        var content = await response.Content.ReadFromJsonAsync<ProviderAccountResponse>(cancellationToken);
        return content!;
    }

    public async Task<bool> SetAccountToForVerification(ForVerificationRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/User/getverified/request", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        response.EnsureSuccessStatusCode();

        return true;
    }

    public async Task<AccountBonusResponse> GetAccountBonus(AccountBonusRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/accountBonus/player/search", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return new AccountBonusResponse();
        }

        var content = await response.Content.ReadFromJsonAsync<AccountBonusResponse>(cancellationToken);
        return content!;
    }
    public async Task<OtpResponse> GenerateOTP(string mobileNumber, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/otp/generate/login", new GenerateOtpRequest(mobileNumber), cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<OtpResponse>(cancellationToken);
        return content!;
    }

    public async Task<ApiBaseResponse<object>> VerifyOTP(VerifyOtpRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/otp/verifyOTP", request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {

            var content = await response.Content.ReadFromJsonAsync<ApiBaseResponse<object>>(cancellationToken);

            return content!;
        }

        return new ApiBaseResponse<object> { Success = true };
    }

    public async Task<object> GetWithdrawalDetail(long transactionId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/withdrawal/details/{transactionId}", cancellationToken);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<WithdrawalVmResponse> GetCurrentAccountWithdrawals(GetCurrentAccountWithdrawalsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/withdrawal/account/current", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);

            return new WithdrawalVmResponse([]);
        }

        var content = await response.Content.ReadFromJsonAsync<ApiBaseResponse<WithdrawalVmResponse>>(cancellationToken);
        return content!.Data;
    }

    public async Task<AccountWithdrawalResponse> CreateAccountWithdrawal(CreateAccountWithdrawalRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/withdrawal", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);

            return new AccountWithdrawalResponse
            {
                Success = false,
                ErrorMessage = $"Failed to create withdrawal request with Status Code: {response.StatusCode}"
            };
        }

        var content = await response.Content.ReadFromJsonAsync<AccountWithdrawalResponse>(cancellationToken);
        return content!;
    }

    public async Task UpdateWithdrawalStatus(UpdateWithdrawalStatusRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/withdrawal/status", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<UserDetailsResponse> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/user/{userId}", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<UserDetailsResponse>(cancellationToken);
        return content!;
    }

    public async Task<object> UpdateProofInfo(UpdateProofInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/proof/info", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception(errorContent);
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> UpdatePersonalDetails(UpdatePersonalDetailsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/personal/details", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> UpdateAddress(UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/address", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> UpdateProfession(UpdateProfessionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/profession", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> UpdateProfileImage(UpdateProfileImageRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/profile/image", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }
}