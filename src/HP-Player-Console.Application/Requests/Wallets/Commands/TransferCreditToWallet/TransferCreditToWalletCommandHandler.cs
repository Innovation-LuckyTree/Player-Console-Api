using HP_Player_Console.Application.Common.Exceptions;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Commands.TransferCreditToWallet;

public class TransferCreditToWalletCommandHandler(IAccountServiceApi accountServiceApi, ICoreAccountApi coreAccountApi) : IRequestHandler<TransferCreditToWalletCommand, TransferAssetResponse>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<TransferAssetResponse> Handle(TransferCreditToWalletCommand request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreAccountApi.AccountCurrent(cancellationToken);

        var transferWalletRequest = new TransferAssetRequest
        {
            AccountCreditId = accountInfo.AccountCreditId,
            AccountWalletId = accountInfo.AccountObjectId,
            Amount = request.Amount,
            Notes = "TRANSFER AMOUNT FROM CREDITS TO WALLET"
        };

        var response = await _accountServiceApi.TransferCreditToWallet(transferWalletRequest, cancellationToken);

        return response;
    }
}