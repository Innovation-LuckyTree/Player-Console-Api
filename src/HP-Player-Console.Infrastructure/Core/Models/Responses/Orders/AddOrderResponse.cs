namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;

public class AddOrderResponse
{
    public long OrderId { get; set; }
    public string TransactionNo { get; set; } = "TRNEXP9999999";
    public IEnumerable<long> OrderItems { get; set; }
    public decimal Amount { get; set; } = 0;
};