using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.PaymentServices.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Deposits.Commands.QrPhDepositRequest;

public class QrPhDepositRequestCommandHandler(IPaymentServicesApi paymentService, ICoreApi coreApi) : IRequestHandler<QrPhDepositRequestCommand, object>
{
    private readonly IPaymentServicesApi _paymentService = paymentService;
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<object> Handle(QrPhDepositRequestCommand request, CancellationToken cancellationToken)
    {
        var currentAccount = await _coreApi.AccountCurrent(cancellationToken);

        var result = await _paymentService.GenerateQR(new GenerateQRRequest(currentAccount.AccountObjectId, request.Amount), cancellationToken);

        return result;
    }
}
