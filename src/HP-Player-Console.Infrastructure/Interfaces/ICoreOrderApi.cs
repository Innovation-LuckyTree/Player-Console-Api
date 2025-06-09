using HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface ICoreOrderApi
{
    Task<OrdersVm> GetAccountOrders(CancellationToken cancellationToken);
    Task<OrdersVm> GetAccountOrdersById(long orderId, CancellationToken cancellationToken);
    Task<OrdersVm> GetAccountOrderByGame(int gameId, CancellationToken cancellationToken);
    Task<OrderItemVm> GetAccountUnusedOrderByGame(int gameId, CancellationToken cancellationToken);
    Task<OrderItemVm> GetAccountCurrentUnusedOrder(int gameId, DateTime openSchedule, CancellationToken cancellationToken);
    Task<AddOrderResponse> AddAccountOrder(AddAccountOrderRequest request, CancellationToken cancellationToken);
    Task UseOrderItemInSchedule(UseOrderItemRequest request, CancellationToken cancellationToken);
    Task RevertOrderItem(UseOrderItemRequest request, CancellationToken cancellationToken);
    Task AdvanceScheduleOrder(AdvanceScheduleOrderItemRequest request, CancellationToken cancellationToken);
    Task<OrderItemVm> GetOrderItems(GetOrderItemsRequest request, CancellationToken cancellationToken);
    Task<OrderItemResponse> GetOrderItemById(long orderItem, CancellationToken cancellationToken);
    Task DeleteOrder(long orderId, CancellationToken cancellationToken);
}
