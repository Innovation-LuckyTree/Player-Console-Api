using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class AccountWithdrawalResponse : ApiResponseBase<AccountWithdrawalDto>
{
}

public class AccountWithdrawalDto
{
    public long WithdrawalId { get; set; }
    public string TransactionNo { get; set; }
}
