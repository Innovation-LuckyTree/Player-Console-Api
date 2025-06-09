namespace HP_Player_Console.Application.Requests.Wallets.Queries;

public record WalletTransactionVm(IEnumerable<WalletTransactionDto> WalletTransactions)
{
    public int Size { get; set; }
    public int Offset { get; set; }
    public int Total { get; set; }
}