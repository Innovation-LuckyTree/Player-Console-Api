using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.RequestToWithdraw;

public record RequestToWithdrawCommand(PaymentMethodTypes PaymentMethod, decimal Amount) : IRequest<ApiBaseResponse<AccountBalanceResponse>>;
