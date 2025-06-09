using HP_Player_Console.Application.Common.Constants;
using HP_Player_Console.Application.Notifications.Transactions;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Commands.WithdrawToAccountingRequest;

public class WithdrawToAccountingRequestCommandHandler(ICoreApi coreApi, IMediator mediator) : IRequestHandler<WithdrawToAccountingRequestCommand, ApiBaseResponse<AccountBalanceResponse>>
{
    private readonly ICoreApi _coreApi = coreApi;
    private readonly IMediator _mediator = mediator;

    public async Task<ApiBaseResponse<AccountBalanceResponse>> Handle(WithdrawToAccountingRequestCommand request, CancellationToken cancellationToken)
    {
        var result = new ApiBaseResponse<AccountBalanceResponse>();

        var createWithdrawalRequest = new CreateAccountWithdrawalRequest(request.Amount)
        {
            AccountId = request.AccountInfoId,
            PaymentMethod = request.PaymentMethod.GetPaymentMethodName()
        };

        createWithdrawalRequest.PaymentMethod = request.PaymentMethod.GetPaymentMethodName();

        var accountWithdrawalTransaction = await _coreApi.CreateAccountWithdrawal(createWithdrawalRequest, cancellationToken);

        // return the result right away if not success
        if (!accountWithdrawalTransaction.Success)
        {
            result.Success = false;
            result.ErrorMessage = accountWithdrawalTransaction.ErrorMessage;
            result.ResponseCode = "500";
            return result;
        }

        var notification = new WithdrawalStatusNotification(accountWithdrawalTransaction.Data.WithdrawalId, WithdrawalTransactionStatuses.PENDING);
        await _mediator.Publish(notification, cancellationToken);

        return result;
    }
}
