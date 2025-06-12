using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;

namespace HappyPlay.Infrastructure.AddressServices;

public class AddressServicesApi : AbstractApiClient, IAddressServicesApi
{
    private readonly IAppConfig _appConfig;

    public AddressServicesApi(HttpClient? client, IAppConfig appConfig) : base(nameof(AddressServicesApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.AddressApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.AddressApiClient.Resource);

        _appConfig = appConfig;

    }

    public async Task<object> GetRegions(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"/api/regions/", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> GetProvince(string regionCode, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"/api/regions/{regionCode}/provinces/", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> GetCitiesByRegion(string regionCode, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"/api/regions/{regionCode}/cities/", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> GetCitiesAndMunicipalitiesByProvince(string provinceCode, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"/api/provinces/{provinceCode}/cities-municipalities/", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }

    public async Task<object> GetBarangayByMunicipality(string municipalityCode, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"/api/cities-municipalities/{municipalityCode}/barangays/", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }
}
