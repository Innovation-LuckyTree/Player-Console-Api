using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Deposits.Commands.GetDepositToken;

public class GetDepositTokenCommandHandler : IRequestHandler<GetDepositTokenCommand, DepositTokenDto>
{
    private readonly decimal _defaultLimit = 100000;
    private readonly decimal _maxDepositAtOnce = 100000;
    private readonly ICoreApi _coreApi;
    private readonly IAccountServiceApi _accountServiceApi;
    private readonly ICurrentUserService _currentUserService;
    private readonly string _merchantName;


    public GetDepositTokenCommandHandler(ICoreApi coreApi, IAccountServiceApi accountServiceApi, IAppConfig appConfig, ICurrentUserService currentUserService)
    {
        _coreApi = coreApi;
        _accountServiceApi = accountServiceApi;
        _merchantName = appConfig.MerchantName;
        _currentUserService = currentUserService;
    }

    public async Task<DepositTokenDto> Handle(GetDepositTokenCommand request, CancellationToken cancellationToken)
    {
        var response = new DepositTokenDto();

        var accountInfo = await _coreApi.AccountCurrent(cancellationToken);
        var providerAccount = accountInfo.PaymentAccount;
        var company = await _coreApi.GetCompanyById(_currentUserService.CompanyId, cancellationToken);
        var walletSettings = await _coreApi.GetWalletSettings(company.Data.CompanyId, cancellationToken);
        var currentAccountTransactions = await _accountServiceApi.GetCurrentAccountTransaction(cancellationToken);

        if (string.IsNullOrEmpty(providerAccount))
        {
            var providerAccountResult = await _coreApi.SetProviderAccount(cancellationToken);
            providerAccount = providerAccountResult.Data.Data.Id;
        }

        if (((currentAccountTransactions?.TotalCashIn ?? 0) + request.Amount) > (walletSettings?.MaximumDepositPerDay ?? _defaultLimit))
        {
            response.ResponseCode = "D002";
            response.Status = "failed";
            response.ErrorMessage = $"Already reached the maximum deposit daily limit. Requested: {request.Amount} Deposited: {currentAccountTransactions?.TotalCashIn}, Maximum limit: {walletSettings?.MaximumDepositPerDay}";
            return response;
        }

        if (request.Amount > (walletSettings?.MaximumDepositAtOnce ?? _maxDepositAtOnce))
        {
            response.ResponseCode = "D003";
            response.Status = "failed";
            response.ErrorMessage = $"Deposit amount should not be greater than the maximum deposit at limit!. Requested: {request.Amount} Maximum Deposit Amount at once: {walletSettings?.MaximumDepositAtOnce}";
            return response;
        }

        if (request.Amount < (walletSettings?.SubsequentMinimumDeposit ?? 0))
        {
            response.ResponseCode = "D004";
            response.Status = "failed";
            response.ErrorMessage = $"Deposit amount should not be less than the minimum deposit limit!. Requested: {request.Amount} Minimum Deposit Amount at once: {walletSettings?.SubsequentMinimumDeposit}";
            return response;
        }


        var requestDepositToken = new DepositTokenRequest
        {
            MerchantName = _merchantName,
            AccountId = providerAccount,
            AccountName = accountInfo.FullName,
            Amount = request.Amount,
            TransactionType = "CASH-IN"
        };

        var depositResponse = await _accountServiceApi.GetDepositToken(requestDepositToken, cancellationToken);

        if (depositResponse == null)
        {
            response.ResponseCode = "D005";
            response.Status = "failed";
            response.ErrorMessage = $"Failed to connect to our payment provider.";
            return response;
        }

        response.Data = depositResponse;

        return response;
    }
}