using HP_Player_Console.Application.Common.Constants;
using HP_Player_Console.Application.Requests.Limits.Queries.GetWalletLimit;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.WithdrawAccountBalance;

public class WithdrawAccountBalanceCommandHandler : IRequestHandler<WithdrawAccountBalanceCommand, ApiBaseResponse<AccountBalanceResponse>>
{
    private readonly decimal _defaultLimit = 100000;
    private readonly decimal _maxWithdrawAtOnce = 100000;
    private readonly IAccountServiceApi _accountServiceApi;
    private readonly ICoreAccountApi _coreAccountApi;
    private readonly ILogger<WithdrawAccountBalanceCommandHandler> _logger;
    private readonly IMediator _mediator;

    public WithdrawAccountBalanceCommandHandler(IAccountServiceApi accountServiceApi, ICoreAccountApi coreAccountApi, ILogger<WithdrawAccountBalanceCommandHandler> logger, IMediator mediator)
    {
        _accountServiceApi = accountServiceApi;
        _coreAccountApi = coreAccountApi;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<ApiBaseResponse<AccountBalanceResponse>> Handle(WithdrawAccountBalanceCommand request, CancellationToken cancellationToken)
    {
        var result = new ApiBaseResponse<AccountBalanceResponse>();
        int withdrawalStatus = WithdrawalTransactionStatuses.COMPLETE;

        var accountInfo = await _coreAccountApi.AccountCurrent(cancellationToken);
        var walletSettings = await _mediator.Send(new GetWalletLimitQuery(), cancellationToken);
        var currentAccountTransactions = await _accountServiceApi.GetCurrentAccountTransaction(cancellationToken);

        if (((currentAccountTransactions?.TotalCashOut ?? 0) + request.Amount) > (walletSettings?.MaximumWithdrawPerDay ?? _defaultLimit))
        {
            result.ResponseCode = "WD002";
            result.Status = "failed";
            result.ErrorMessage = $"Already reached the maximum withdraw daily limit. Requested: {request.Amount} withdraw: {currentAccountTransactions?.TotalCashIn}, Maximum limit: {walletSettings?.MaximumWithdrawPerDay}";
            return result;
        }

        if (request.Amount > (walletSettings?.MaximumWithdrawAtOnce ?? _maxWithdrawAtOnce))
        {
            result.ResponseCode = "WD003";
            result.Status = "failed";
            result.ErrorMessage = $"Withdrawal amount should not be greater than the maximum withdraw limit. Requested: {request.Amount} Maximum withdraw Amount at Once: {walletSettings?.MaximumWithdrawAtOnce}";
            return result;
        }

        if (request.Amount < (walletSettings?.SubsequentMinimumWithdraw ?? 0))
        {
            result.ResponseCode = "WD004";
            result.Success = false;
            result.Status = "failed";
            result.ErrorMessage = $"Withdrawal amount should not be less than the minimum withdraw limit!. Requested: {request.Amount} Minimum Withdraw Amount at once: {walletSettings?.SubsequentMinimumWithdraw}";
            return result;
        }

        var createWithdrawalRequest = new CreateAccountWithdrawalRequest(request.Amount)
        {
            AccountId = accountInfo.AccountInfoId
        };

        var accountWithdrawalTransaction = await _coreAccountApi.CreateAccountWithdrawal(createWithdrawalRequest, cancellationToken);

        if (!accountWithdrawalTransaction.Success)
        {
            result.Success = false;
            result.ResponseCode = "400";
            result.ErrorMessage = accountWithdrawalTransaction.ErrorMessage;
            return result;
        }

        var creditTransaction = new AddCreditTransactionRequest(currentAccountTransactions.WalletBalance.AccountId, accountWithdrawalTransaction.Data.WithdrawalId.ToString(), request.Amount, "Withdrawal request from app(GCASH)");

        try
        {
            var accountWithdrawResult = await _accountServiceApi.AccountWithdraw(creditTransaction, cancellationToken);
            result.Success = true;
            result.Data = accountWithdrawResult;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in sending account withdraw to wallet! {ex.Message}");
            
            var updateWithdrawalStatus = new UpdateWithdrawalStatusRequest()
            {
                TransactionId = accountWithdrawalTransaction.Data.WithdrawalId,
                Status = 4 // FAILED 
            };

            await _coreAccountApi.UpdateWithdrawalStatus(updateWithdrawalStatus, cancellationToken);

            result.Success = false;
            result.ErrorMessage = "Failed to withdraw transaction";
        }

        return result;
    }
}