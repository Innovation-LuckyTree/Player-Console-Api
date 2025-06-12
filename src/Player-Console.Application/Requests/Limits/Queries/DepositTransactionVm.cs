using HP_Player_Console.Application.Requests.Wallets.Queries;

namespace HP_Player_Console.Application.Requests.Limits.Queries;

public record DepositTransactionVm(IEnumerable<AccountTransactionDto> DepositTransactions)
{
  public int Size { get; set; }
  public int Offset { get; set; }
  public int Total { get; set; }
}
