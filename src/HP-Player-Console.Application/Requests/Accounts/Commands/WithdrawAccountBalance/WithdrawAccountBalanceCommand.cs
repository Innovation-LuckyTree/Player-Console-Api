using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.WithdrawAccountBalance;

public record WithdrawAccountBalanceCommand(decimal Amount) : IRequest<ApiBaseResponse<AccountBalanceResponse>>;
