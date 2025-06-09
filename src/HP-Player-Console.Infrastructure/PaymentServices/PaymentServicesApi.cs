using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.PaymentServices.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace HP_Player_Console.Infrastructure.PaymentServices;

public class PaymentServicesApi : AbstractApiClient, IPaymentServicesApi
{
    private readonly string _clientId;
    private readonly ILogger<PaymentServicesApi> _logger;

    public PaymentServicesApi(HttpClient? client, IAppConfig appConfig, ILogger<PaymentServicesApi> logger) : base(nameof(PaymentServicesApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.PaymentServiceApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.PaymentServiceApiClient.Resource);

        _clientId = appConfig.AppId;
        _logger = logger;
    }

    #region QRPH
    public async Task<object> GenerateQR(GenerateQRRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/provider/account/inward", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        
        return content!;
    }
    #endregion

    #region Credit
    public async Task<object> AddCredit(AddCreditRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/credit", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }
    #endregion

    #region Withdraw
    public async Task<object> SendWithdrawRequest(AddWithdrawRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/credit", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<CreditTransactionResponse> GetPlayerRequestHistory(SearchWithdrawHistoryRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/credit/request/player/search", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);

            return new CreditTransactionResponse
            {
                ResponseCode = "400",
                Success = false,
                ErrorMessage = $"Failed to retrieve withdrawal history with Status Code: {response.StatusCode}"
            };
        }

        var content = await response.Content.ReadFromJsonAsync<CreditTransactionResponse>();
        return content!;
    }

    #endregion

}