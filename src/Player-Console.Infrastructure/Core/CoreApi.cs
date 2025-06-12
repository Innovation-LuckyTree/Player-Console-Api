using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net;
using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Requests.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Requests.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Announcements;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Limits;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Company;

namespace HP_Player_Console.Infrastructure.Core;

public class CoreApi : AbstractApiClient, ICoreApi
{
    private readonly string _clientId;
    private readonly ILogger<CoreApi> _logger;

    public CoreApi(HttpClient? client, IAppConfig appConfig, ILogger<CoreApi> logger) : base(nameof(CoreApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.CoreApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.CoreApiClient.Resource);

        _clientId = appConfig.AppId;
        _logger = logger;
    }

    #region Company
    public async Task<ApiBaseResponse<CompanyResponse>> GetCompanyById(string companyid, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/company/{companyid}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<ApiBaseResponse<CompanyResponse>>(cancellationToken);
        return content!;
    }

    public async Task<CompanyWalletSettingsResponse> GetWalletSettings(int companyId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/wallet/settings?companyId={companyId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);

            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<CompanyWalletSettingsResponse>(cancellationToken);
        return content!;
    }
    #endregion

    #region Upload Image
    public async Task<UploadFileResponse> UploadImage(IFormFile fileRequest, CancellationToken cancellationToken)
    {
        var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(fileRequest.OpenReadStream());
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(fileRequest.ContentType);

        content.Add(fileContent, "file", fileRequest.FileName);

        var response = await _client.PostAsync($"api/upload", content, cancellationToken);

        var respContent = await response.Content.ReadFromJsonAsync<UploadFileResponse>(cancellationToken);
        return respContent!;
    }

    public async Task<UploadFileResponse> UploadBase64Image(UploadStringImage request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/upload/base64image", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<UploadFileResponse>(cancellationToken);
        return content!;
    }

    public async Task<UploadFileResponse> GetImageByName(string fileName, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/upload/{fileName}", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<UploadFileResponse>(cancellationToken);
        return content!;
    }
    #endregion

    #region Limits

    public async Task<AdminExclusionResponse> GetAccountAdminExclusion(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/administrative/exclusion/account/{accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<AdminExclusionResponse>(cancellationToken);
        return content!;
    }

    public async Task<AccountAdminLimitResponse> GetAccountAdminLimitResponse(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/administrative/account/limit/{accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new(new(), new());
        }

        var content = await response.Content.ReadFromJsonAsync<AccountAdminLimitResponse>(cancellationToken);
        return content!;
    }

    public async Task<SelfLimitResponse> GetSelfLimitExclusion(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/administrative/self-limit/account/{accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<SelfLimitResponse>(cancellationToken);
        return content!;
    }
    #endregion

    #region Livestream
    public async Task<object> GetLatestLivestream(int companyId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/livestream/{companyId}/latest", cancellationToken);
        if (!response.IsSuccessStatusCode)
            return new();

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }
    #endregion

    #region Announcement
    public async Task<object> GetActiveAnnouncements(ActiveAnnouncementsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/announcement/active", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return new();

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }
    #endregion

    #region Self Exclusion

    public async Task<SelfExclusionVmResponse> GetActiveExlusion(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/selfExclusion?AccountId={accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<SelfExclusionVmResponse>(cancellationToken);
        return content!;
    }

    public async Task<SelfExclusionVmResponse> CreateSelfExclusion(SelfExclusionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/selfExclusion", request, cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<SelfExclusionVmResponse>(cancellationToken);
        return content!;
    }

    public async Task<SelfExclusionVmResponse> UpdateActiveExclusion(SelfExclusionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/selfExclusion", request, cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<SelfExclusionVmResponse>(cancellationToken);
        return content!;
    }
    #endregion
}