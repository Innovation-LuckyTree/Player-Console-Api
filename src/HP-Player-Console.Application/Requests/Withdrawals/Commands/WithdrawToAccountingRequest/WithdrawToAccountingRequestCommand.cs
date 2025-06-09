using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Commands.WithdrawToAccountingRequest;

public record WithdrawToAccountingRequestCommand(decimal Amount, long AccountInfoId, PaymentMethodTypes PaymentMethod) : IRequest<ApiBaseResponse<AccountBalanceResponse>>;
