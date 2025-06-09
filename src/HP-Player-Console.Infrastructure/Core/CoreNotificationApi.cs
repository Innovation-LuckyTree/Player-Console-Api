using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;

namespace HP_Player_Console.Infrastructure.Core;

public class CoreNotificationApi : AbstractApiClient, ICoreNotificationApi
{
    private readonly ILogger<CoreNotificationApi> _logger;

    public CoreNotificationApi(HttpClient? client, IAppConfig appConfig, ILogger<CoreNotificationApi> logger) : base(nameof(CoreNotificationApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.CoreApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.CoreApiClient.Resource);

        _logger = logger;
    }

    public async Task PostAccountNotification(NotificationInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/notification", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);
        }
    }

    public async Task PostAccountNotificationList(NotificationListRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/notification/list", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);
        }
    }

    public async Task PostNotificationByNameRequest(NotificationByNameRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/notification/generate/account/list", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);
        }
    }

    public async Task<GetNotificationListResponse> GetSearchNotifications(NotificationSearchRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/notification/search", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<GetNotificationListResponse>(cancellationToken);
        return content!;
    }

    public async Task<MarkAllAsReadResponse> MarkAllReadNotification(MarkAllReadRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/notification/mark-all", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<MarkAllAsReadResponse>(cancellationToken);
        return content!;
    }
    public async Task<NotificationVm> UpdateNotification(UpdateNotificationRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/notification", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<NotificationVm>(cancellationToken);
        return content!;
    }
}