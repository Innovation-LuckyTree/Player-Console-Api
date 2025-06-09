namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;

public record GetOrderItemsRequest(IEnumerable<long> OrderItemIds);