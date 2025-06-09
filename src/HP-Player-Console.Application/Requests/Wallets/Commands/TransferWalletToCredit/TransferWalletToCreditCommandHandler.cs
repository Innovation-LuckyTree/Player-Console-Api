using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Commands.TransferWalletToCredit;

public class TransferWalletToCreditCommandHandler(IAccountServiceApi accountServiceApi, ICoreApi coreApi) : IRequestHandler<TransferWalletToCreditCommand, TransferAssetResponse>
{
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<TransferAssetResponse> Handle(TransferWalletToCreditCommand request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreApi.AccountCurrent(cancellationToken);

        var transferCreditRequest = new TransferAssetRequest
        {
            AccountCreditId = accountInfo.AccountCreditId,
            AccountWalletId = accountInfo.AccountObjectId,
            Amount = request.Amount,
            Notes = "TRANSFER AMOUNT FROM WALLET TO CREDITS"
        };

        var response = await _accountServiceApi.TransferWalletToCredit(transferCreditRequest, cancellationToken);

        return response;
    }
}
