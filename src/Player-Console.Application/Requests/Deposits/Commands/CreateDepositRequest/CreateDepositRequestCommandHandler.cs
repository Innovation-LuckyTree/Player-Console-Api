using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Application.Requests.Deposits.Commands.QrPhDepositRequest;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.PaymentServices.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Deposits.Commands.CreateDepositRequest;

public class CreateDepositRequestCommandHandler(IPaymentServicesApi paymentService, ICoreApi coreApi, IMediator mediator) : IRequestHandler<CreateDepositRequestCommand, object>
{
    private readonly IPaymentServicesApi _paymentService = paymentService;
    private readonly ICoreApi _coreApi = coreApi;
    private readonly IMediator _mediator = mediator;

    public async Task<object> Handle(CreateDepositRequestCommand request, CancellationToken cancellationToken)
    {
        // var paymentInfo = await _coreApi.GetPlayerAgentInfo(cancellationToken);

        if (request.PaymentMethod == PaymentMethodTypes.QrPh)
        {
            var qrResult = await _mediator.Send(new QrPhDepositRequestCommand(request.Amount), cancellationToken);

            return qrResult;
        }

        // var creditRequest = new AddCreditRequest(paymentInfo)
        // {
        //     CreditType = 1,
        //     Amount = request.Amount
        // };

        // var result = await _paymentService.AddCredit(creditRequest, cancellationToken);

        // var notificationRequest = 

        return null;
    }
}


