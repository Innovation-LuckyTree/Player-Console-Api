using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Commands.WithdrawToAgentRequest;

public record WithdrawToAgentRequestCommand(decimal Amount, long AccountInfoId, PaymentMethodTypes PaymentMethod) : IRequest<ApiBaseResponse<AccountBalanceResponse>>;
