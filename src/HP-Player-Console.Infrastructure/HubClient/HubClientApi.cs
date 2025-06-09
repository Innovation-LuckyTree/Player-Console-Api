using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.HubClient.Models;

namespace HP_Player_Console.Infrastructure.HubClient;

public class HubClientApi : AbstractApiClient, IHubClientApi
{
    private readonly string _clientId;

    public HubClientApi(HttpClient? client, IAppConfig appConfig) : base(nameof(HubClientApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.HubClientApi.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.HubClientApi.Resource);

        _clientId = appConfig.AppId;
    }

    public async Task<LuckyPickResponse> GetLuckyPick(int count, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"/lucky-pick/?count={count}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new LuckyPickResponse([]);

        var content = await response.Content.ReadFromJsonAsync<LuckyPickResponse>(cancellationToken);
        return content;
    }
}