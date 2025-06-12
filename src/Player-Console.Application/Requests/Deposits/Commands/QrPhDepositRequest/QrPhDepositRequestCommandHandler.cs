using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.PaymentServices.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Deposits.Commands.QrPhDepositRequest;

public class QrPhDepositRequestCommandHandler(IPaymentServicesApi paymentService, ICoreAccountApi coreAccountApi) : IRequestHandler<QrPhDepositRequestCommand, object>
{
    private readonly IPaymentServicesApi _paymentService = paymentService;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(QrPhDepositRequestCommand request, CancellationToken cancellationToken)
    {
        var currentAccount = await _coreAccountApi.AccountCurrent(cancellationToken);

        var result = await _paymentService.GenerateQR(new GenerateQRRequest(currentAccount.AccountObjectId, request.Amount), cancellationToken);

        return result;
    }
}
