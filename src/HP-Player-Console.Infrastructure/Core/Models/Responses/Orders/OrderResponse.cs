namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;

public class OrderResponse
{
    public long OrderId { get; set; }
    public int GameId { get; set; }
    public string TransactionNo { get; set; }
    public decimal TotalAmount { get; set; }
    public int TotalNoOfItems { get; set; }
    public DateTime DateOfTransaction { get; set; }
}
