using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Limits.Queries.GetDepositLimit;

public class GetDepositLimitQuery : IRequest<ApiBaseResponse<DepositTransactionVm>>;
