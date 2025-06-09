using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using HP_Player_Console.Infrastructure.PaymentServices.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Commands.WithdrawToAgentRequest;

public class WithdrawToAgentRequestCommandHandler(ICoreApi coreApi, IPaymentServicesApi paymentServicesApi) : IRequestHandler<WithdrawToAgentRequestCommand, ApiBaseResponse<AccountBalanceResponse>>
{
    private readonly ICoreApi _coreApi = coreApi;
    private readonly IPaymentServicesApi _paymentServicesApi = paymentServicesApi;

    public async Task<ApiBaseResponse<AccountBalanceResponse>> Handle(WithdrawToAgentRequestCommand request, CancellationToken cancellationToken)
    {
        var paymentInfo = await _coreApi.GetPlayerAgentInfo(cancellationToken);
        var response = new ApiBaseResponse<AccountBalanceResponse>()
        {
            Data = new AccountBalanceResponse
            {
                AccountId = paymentInfo.Player.AccountObjId,
                AccountType = paymentInfo.Player.AccountType
            }
        };

        var withdrawRequest = new AddWithdrawRequest(paymentInfo)
        {
            CreditType = 3,
            Amount = request.Amount
        };

        var result = await _paymentServicesApi.SendWithdrawRequest(withdrawRequest, cancellationToken);

        return response;
    }
}
