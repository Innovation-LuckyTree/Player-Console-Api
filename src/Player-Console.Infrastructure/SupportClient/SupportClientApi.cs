using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Support.Requests;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Case;

namespace HP_Player_Console.Infrastructure.AccountServices;

public class SupportClientApi : AbstractApiClient, ISupportClientApi
{
    private readonly IAppConfig _appConfig;

    public SupportClientApi(HttpClient? client, IAppConfig appConfig) : base(nameof(SupportClientApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.SupportApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.SupportApiClient.Resource);

        _appConfig = appConfig;
    }

    public async Task<object> CreateCase(CreateCaseRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/case", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> UpdateCaseOwner(UpdateCaseOwnerRquest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync("api/case", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> SearchCases(SearchCaseRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/case/search", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> GetCaseStatuses(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/casestatus", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<CaseDto> GetCaseById(long caseId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/case/{caseId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<CaseDto>();
        return content!;
    }

    public async Task<object> GetCaseOrganizations(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/organization", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> GetCategoryList(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/category", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> GetCategoryByType(int typeId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/category/{typeId}", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }
    public async Task<IEnumerable<CommentDto>> GetCaseComments(long CaseId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/Case/comments?CaseId={CaseId}", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<IEnumerable<CommentDto>>();
        return content!;
    }
}
