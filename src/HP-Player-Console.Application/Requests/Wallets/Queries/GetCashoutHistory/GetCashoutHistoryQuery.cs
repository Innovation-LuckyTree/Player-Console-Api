using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetCashoutHistory;

public class GetCashoutHistoryQuery : IRequest<ApiBaseResponse<WalletTransactionVm>>
{

}
