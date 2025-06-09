namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;

public class AdvanceScheduleOrderItems
{
    public int GameType { get; set; }
    public IEnumerable<long> OrderItems { get; set; }
}
