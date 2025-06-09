using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Commands.ProcessBetCommand;

public record ProcessBetCommand(CurrentAccountResponse Account, string TransactionNo, decimal Amount, bool IsBonus) : IRequest<bool>;
