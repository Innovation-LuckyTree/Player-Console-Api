namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;

public class AddAccountOrderRequest
{
    public int GameId { get; set; }
    public IEnumerable<OrderItemRequest> OrderItems { get; set; }
    public int TotalItems { get; set; } = 1;
    public decimal TotalAmount { get; set; }
    public bool IsBonus { get; set; }
}
