using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.PaymentServices.Models;

public record SearchWithdrawHistoryRequest(Guid AccountObjId)
{
    public PagedQuery PagedQuery { get; set; } =
        new PagedQuery
        {
            Search = string.Empty,
            PageNumber = 0,
            PageSize = 10
        };
}
