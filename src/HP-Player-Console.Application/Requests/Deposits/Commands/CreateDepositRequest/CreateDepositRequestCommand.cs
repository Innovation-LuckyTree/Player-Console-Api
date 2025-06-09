using HP_Player_Console.Application.Common.Enums;
using MediatR;

namespace HP_Player_Console.Application.Requests.Deposits.Commands.CreateDepositRequest;

public class CreateDepositRequestCommand : IRequest<object>
{
    public PaymentMethodTypes PaymentMethod { get; set; }
    public decimal Amount { get; set; }
}
