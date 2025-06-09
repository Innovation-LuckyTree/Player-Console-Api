namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;

public record UseOrderItemRequest(long GameScheduleId, IEnumerable<long> OrderItems);
