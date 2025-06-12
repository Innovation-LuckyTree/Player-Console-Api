using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;
using Microsoft.Extensions.Logging;
using System.Net;

namespace HP_Player_Console.Infrastructure.Core;

public class CoreOrderApi : AbstractApiClient, ICoreOrderApi
{
    private readonly ILogger<CoreOrderApi> _logger;

    public CoreOrderApi(HttpClient? client, IAppConfig appConfig, ILogger<CoreOrderApi> logger) : base(nameof(CoreOrderApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.CoreApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.CoreApiClient.Resource);

        _logger = logger;
    }
    
    public async Task<OrdersVm> GetAccountOrders(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/order", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrdersVm>();
        return content!;
    }

    public async Task<OrdersVm> GetAccountOrdersById(long orderId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/{orderId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrdersVm>();
        return content!;
    }

    public async Task<OrdersVm> GetAccountOrderByGame(int gameId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/game/{gameId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrdersVm>();
        return content!;
    }

    public async Task<OrderItemVm> GetAccountUnusedOrderByGame(int gameId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/unused/{gameId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrderItemVm>(cancellationToken);
        return content!;
    }
    public async Task<OrderItemVm> GetAccountCurrentUnusedOrder(int gameId, DateTime openSchedule, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/unused/{gameId}/current?openschedule={openSchedule.ToString("s").Replace(":", "%3A")}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrderItemVm>(cancellationToken);
        return content!;
    }

    public async Task<AddOrderResponse> AddAccountOrder(AddAccountOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);

            _logger.LogError(errorContent);

            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AddOrderResponse>();
        return content!;
    }

    public async Task UseOrderItemInSchedule(UseOrderItemRequest request, CancellationToken cancellationToken)
    {
        var requestList = new
        {
            ScheduleOrderItems = new List<UseOrderItemRequest>()
            {
                request
            }
        };

        var response = await _client.PostAsJsonAsync("api/order/schedule", requestList, cancellationToken);

        // TODO: there should be a fail handler for this
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Failed to tagged order items to used!. Order Item Ids {string.Join(',', request.OrderItems)}");
        }
    }

    public async Task RevertOrderItem(UseOrderItemRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order/schedule/revert", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task AdvanceScheduleOrder(AdvanceScheduleOrderItemRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order/schedule/advance", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<OrderItemVm> GetOrderItems(GetOrderItemsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order/items", request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<OrderItemVm>();
        return content!;
    }

    public async Task<OrderItemResponse> GetOrderItemById(long orderItem, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/item/detail/{orderItem}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new OrderItemResponse();
        }

        var content = await response.Content.ReadFromJsonAsync<OrderItemResponse>();
        return content!;
    }

    public async Task DeleteOrder(long orderId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync($"api/order/{orderId}", cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}