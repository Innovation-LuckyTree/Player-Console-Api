namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;

public record OrderItemRequest(int GameTypeId, string Values, decimal AmountBet, int BetItemType)
{
    public decimal ExcessAmount { get; set; } = 0;
    public bool Valid { get; set; } = true;
    public bool HasExcessAmount { get; set; } = false;
}
