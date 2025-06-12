namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;

public class OrderItemResponse
{
    public long OrderItemId { get; set; }
    public bool Used { get; set; }
    public string TransactionNo { get; set; }
    public string Values { get; set; }
    public int GameTypeId { get; set; }
    public int BetItemType { get; set; }
    public int GameReferenceId { get; set; }
    public string GameType { get; set; }
    public decimal AmountBet { get; set; }
    public DateTime? UsedDate { get; set; }
    public decimal ExcessAmount { get; set; } = 0;
    public bool HasExcessAmount { get; set; } = false;
}
