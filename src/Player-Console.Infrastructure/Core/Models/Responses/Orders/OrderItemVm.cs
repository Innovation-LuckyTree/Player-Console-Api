namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;

public class OrderItemVm
{
    public IEnumerable<OrderItemResponse> OrderItems { get; set; }
    public decimal TotalAmount { get; set; }
    public int TotalCount { get; set; }
}