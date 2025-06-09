using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Application.Requests.Accounts.Commands.WithdrawAccountBalance;
using HP_Player_Console.Application.Requests.Limits.Queries.GetWalletLimit;
using HP_Player_Console.Application.Requests.Withdrawals.Commands.WithdrawToAccountingRequest;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.RequestToWithdraw;

public class RequestToWithdrawCommandHandler(IAccountServiceApi accountServiceApi, ICoreAccountApi coreAccountApi, IMediator mediator) : IRequestHandler<RequestToWithdrawCommand, ApiBaseResponse<AccountBalanceResponse>>
{
    private readonly decimal _defaultLimit = 100000;
    private readonly decimal _maxWithdrawAtOnce = 100000;
    private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;
    private readonly IMediator _mediator = mediator;

    public async Task<ApiBaseResponse<AccountBalanceResponse>> Handle(RequestToWithdrawCommand request, CancellationToken cancellationToken)
    {
        var result = new ApiBaseResponse<AccountBalanceResponse>();

        var walletSettings = await _mediator.Send(new GetWalletLimitQuery(), cancellationToken);
        var accountInfo = await _coreAccountApi.AccountCurrent(cancellationToken);
        var currentAccountTransactions = await _accountServiceApi.GetCurrentAccountTransaction(cancellationToken);

        if (((currentAccountTransactions?.TotalCashOut ?? 0) + request.Amount) > (walletSettings?.MaximumWithdrawPerDay ?? _defaultLimit))
        {
            result.ResponseCode = "WD002";
            result.Status = "failed";
            result.Success = false;
            result.ErrorMessage = $"Already reached the maximum withdraw daily limit. Requested: {request.Amount} withdraw: {currentAccountTransactions?.TotalCashIn}, Maximum limit: {walletSettings?.MaximumWithdrawPerDay}";
            return result;
        }

        if (request.Amount > (walletSettings?.MaximumWithdrawAtOnce ?? _maxWithdrawAtOnce))
        {
            result.ResponseCode = "WD003";
            result.Status = "failed";
            result.Success = false;
            result.ErrorMessage = $"Withdrawal amount should not be greater than the maximum withdraw limit. Requested: {request.Amount} Maximum withdraw Amount at Once: {walletSettings?.MaximumWithdrawAtOnce}";
            return result;
        }

        if (request.Amount < (walletSettings?.SubsequentMinimumWithdraw ?? 0))
        {
            result.ResponseCode = "WD004";
            result.Status = "failed";
            result.Success = false;
            result.ErrorMessage = $"Withdrawal amount should not be less than the minimum withdraw limit!. Requested: {request.Amount} Minimum Withdraw Amount at once: {walletSettings?.SubsequentMinimumWithdraw}";
            return result;
        }

        return request.PaymentMethod switch
        {
            PaymentMethodTypes.GCash => await _mediator.Send(new WithdrawAccountBalanceCommand(request.Amount), cancellationToken),
            PaymentMethodTypes.Cash => await _mediator.Send(new WithdrawToAccountingRequestCommand(request.Amount, accountInfo.AccountInfoId, request.PaymentMethod), cancellationToken),
            _ => await _mediator.Send(new WithdrawAccountBalanceCommand(request.Amount), cancellationToken)
        };
    }
}