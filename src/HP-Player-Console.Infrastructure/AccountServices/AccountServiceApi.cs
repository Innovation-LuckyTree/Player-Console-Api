using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using Microsoft.Extensions.Logging;

namespace HP_Player_Console.Infrastructure.AccountServices;

public class AccountServiceApi : AbstractApiClient, IAccountServiceApi
{
    private readonly IAppConfig _appConfig;
    private readonly ILogger<AccountServiceApi> _logger;

    public AccountServiceApi(HttpClient? client, IAppConfig appConfig, ILogger<AccountServiceApi> logger) : base(nameof(AccountServiceApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.AccountServicesApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.AccountServicesApiClient.Resource);

        _appConfig = appConfig;
        _logger = logger;
    }

    #region Wallets
    public async Task<T> GetAccountWalletTransaction<T>(CancellationToken cancellationToken) where T : class
    {
        var response = await _client.GetAsync($"api/accountTransaction/transactions", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        return content!;
    }

    public async Task<AccountBalanceResponse> GetAccountBalanceByAccountId(Guid accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/AccountTransaction/credits/{accountId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AccountBalanceResponse>(cancellationToken);
        return content!;
    }

    public async Task<AccountBalanceResponse> GetAccountWalletBalance(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/accountTransaction/credits", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AccountBalanceResponse>(cancellationToken);
        return content!;
    }

    public async Task<CurrentAccountTransactionResponse> GetCurrentAccountTransaction(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/AccountTransaction/current", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<CurrentAccountTransactionResponse>(cancellationToken);
        return content!;
    }

    public async Task AccountCashIn(AddDebitTransactionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/accountTransaction/cash-in", request, cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task<AccountBalanceResponse> AccountWithdraw(AddCreditTransactionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/accountTransaction/account/withdraw", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<WithdrawAccountBalanceResponse>(cancellationToken);
        return content?.Data;
    }

    public async Task<T> GetWalletTransactions<T>(SearchTransactionRequest request, CancellationToken cancellationToken) where T : class
    {
        var response = await _client.PostAsJsonAsync("api/accounttransaction/transactions/search", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        return content!;
    }
    #endregion

    #region Payment Provider
    public async Task<DepositTokenData> GetDepositToken(DepositTokenRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/deposit/token", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<DepositTokenResponse>(cancellationToken);
        return content.Data?.Data;
    }
    #endregion

    #region Account Credits
    public async Task<AccountBalanceResponse> GetAccountCredits(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/credits/account", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AccountBalanceResponse>(cancellationToken);
        return content!;
    }

    public async Task<bool> AddBet(AddCreditTransactionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/credits/bet", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        return true;
    }

    public async Task<T> GetAccountCreditTransactions<T>(CancellationToken cancellationToken) where T : class
    {
        var response = await _client.GetAsync($"api/accountTransaction/transactions", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        return content!;
    }

    public async Task<TransferAssetResponse> TransferWalletToCredit(TransferAssetRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/credits/transfer/wallet-credit", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<TransferAssetResponse>(cancellationToken);
        return content!;
    }

    public async Task<TransferAssetResponse> TransferCreditToWallet(TransferAssetRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/credits/transfer/credit-wallet", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errMsg = await response.Content.ReadAsStringAsync(cancellationToken);

            _logger.LogError(errMsg);

            return new TransferAssetResponse
            {
                ResponseCode = "110",
                Success = false,
                ErrorMessage = "Failed to transfer wallet to credit!"
            };
        }

        var content = await response.Content.ReadFromJsonAsync<TransferAssetResponse>(cancellationToken);
        return content!;
    }

    public async Task<T> GetCreditTransactions<T>(SearchTransactionRequest request, CancellationToken cancellationToken) where T : class
    {
        var response = await _client.PostAsJsonAsync("api/credits/transactions/search", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        return content!;
    }
    #endregion

    #region bonus Account
    public async Task<AccountBonusDetail> GetBonusAccount(Guid accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/bonus-account/credits/{accountId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return new();
        }

        var content = await response.Content.ReadFromJsonAsync<AccountBonusDetail>(cancellationToken);
        return content!;
    }

    public async Task<bool> AddBetUsingBonusAccount(AddBetUsingBonusRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/bonus-account/bet", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        return true;
    }

    public async Task<T> GetBonusTransactions<T>(SearchTransactionRequest request, CancellationToken cancellationToken) where T : class
    {
        var response = await _client.PostAsJsonAsync("api/bonus-account/transactions/search", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        return content!;
    }
    #endregion
}
