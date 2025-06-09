using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Commands.TransferWalletToCredit;

public record TransferWalletToCreditCommand(decimal Amount) : IRequest<TransferAssetResponse>;
