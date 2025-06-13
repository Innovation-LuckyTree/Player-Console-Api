using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.HuiduClient.Models;
using HP_Player_Console.Infrastructure.Interfaces;

namespace HP_Player_Console.Infrastructure.HuiduClient;

public class HuiduClientApi : AbstractApiClient, IHuiduClientApi
{
    private readonly string _clientId;
    private readonly string _key;
    private readonly string _agencyId;

    public HuiduClientApi(HttpClient? client, IAppConfig appConfig) : base(nameof(HuiduClientApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.HuiduClientApi.BaseAddressUrl);

        _clientId = appConfig.AppId;
        _key = appConfig.HuiduClientApi.ClientKey;
        _agencyId = appConfig.HuiduClientApi.AgencyId;
    }

    public async Task<string> GetGame(string accountId, string gameId, string amount, CancellationToken cancellationToken)
    {
        var rawPayload = new GetGamesPayload()
        {
            AgencyUid = _agencyId,
            GameUid = gameId,
            CreditAmount = amount,
            MemberAccount = accountId
        };

        var payload = AesEncryptionHelper.Encrypt(rawPayload.ToJson(), _key);

        var body = new GetGamesRequest()
        {
            AgencyUid = _agencyId,
            TimeStamp = rawPayload.TimeStamp,
            Payload = payload
        };

        var response = await _client.PostAsJsonAsync($"/game/v1", body, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return string.Empty;

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return content;
    }
}