using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.TransferHistory;

public class TransferHistoryQuery : IRequest<ApiBaseResponse<WalletTransactionVm>>
{

}
