using HP_Player_Console.Application.Requests.Wallets.Queries;

namespace HP_Player_Console.Application.Requests.Limits.Queries;

public record WithdrawalTransactionVm(IEnumerable<AccountTransactionDto> WithdrawalTransactions)
{
  public int Size { get; set; }
  public int Offset { get; set; }
  public int Total { get; set; }
}
