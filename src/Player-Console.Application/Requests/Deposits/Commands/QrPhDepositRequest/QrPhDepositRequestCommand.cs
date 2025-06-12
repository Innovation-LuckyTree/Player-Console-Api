using MediatR;

namespace HP_Player_Console.Application.Requests.Deposits.Commands.QrPhDepositRequest;

public record QrPhDepositRequestCommand(decimal Amount) : IRequest<object>;
