using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using System.Net.Http.Json;
using HP_Player_Console.Infrastructure.Core.Models.Requests.OTP;
using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Orders;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Orders;
using HP_Player_Console.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Withdrawals;
using System.Net;
using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Requests.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Requests.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Profiles;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Announcements;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Limits;

namespace HP_Player_Console.Infrastructure.Core;

public class CoreApi : AbstractApiClient, ICoreApi
{
    private readonly string _clientId;
    private readonly ILogger<CoreApi> _logger;

    public CoreApi(HttpClient? client, IAppConfig appConfig, ILogger<CoreApi> logger) : base(nameof(CoreApi), client)
    {
        _client.BaseAddress = new Uri(appConfig.CoreApiClient.BaseAddressUrl);
        _client.DefaultRequestHeaders.Add("Resource", appConfig.CoreApiClient.Resource);

        _clientId = appConfig.AppId;
        _logger = logger;
    }

    #region Account
    public async Task<CurrentAccountResponse> AccountCurrent(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/player/current", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<CurrentAccountResponse>();
        return content!;
    }

    public async Task<PlayersAgentResponse> GetPlayerAgentInfo(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/player/agent-info", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<PlayersAgentResponse>();
        return content!;
    }

    public async Task<FindPlayerResponse> FindPlayer(FindPlayerRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/player/find", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<FindPlayerResponse>();
        return content!;
    }

    public async Task UpdateUserPassword(UpdateUserPasswordRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/account/new/password", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        response.EnsureSuccessStatusCode();
    }

    public async Task<ProviderAccountResponse> SetProviderAccount(CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/account/payment-provider", new { }, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Connecting to core api was unsuccessful.");
        }

        var content = await response.Content.ReadFromJsonAsync<ProviderAccountResponse>();
        return content!;
    }

    public async Task<bool> SetAccountToForVerification(ForVerificationRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/User/getverified/request", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        response.EnsureSuccessStatusCode();

        return true;
    }

    public async Task<AccountBonusResponse> GetAccountBonus(AccountBonusRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/accountBonus/player/search", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return new AccountBonusResponse();
        }

        var content = await response.Content.ReadFromJsonAsync<AccountBonusResponse>();
        return content!;
    }

    #endregion

    #region OTP Services
    public async Task<OtpResponse> GenerateOTP(string mobileNumber, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/otp/generate/login", new GenerateOtpRequest(mobileNumber), cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<OtpResponse>();
        return content!;
    }

    public async Task<ApiBaseResponse<object>> VerifyOTP(VerifyOtpRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/otp/verifyOTP", request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {

            var content = await response.Content.ReadFromJsonAsync<ApiBaseResponse<object>>(cancellationToken);

            return content!;
        }

        return new ApiBaseResponse<object> { Success = true };
    }

    public async Task<OtpDataResponse> GetPendingOtp(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/OTP/pending", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OtpDataResponse>();
        return content!;
    }
    #endregion

    #region Orders
    public async Task<OrdersVm> GetAccountOrders(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("api/order", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrdersVm>();
        return content!;
    }

    public async Task<OrdersVm> GetAccountOrdersById(long orderId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/{orderId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrdersVm>();
        return content!;
    }

    public async Task<OrdersVm> GetAccountOrderByGame(int gameId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/game/{gameId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrdersVm>();
        return content!;
    }

    public async Task<OrderItemVm> GetAccountUnusedOrderByGame(int gameId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/unused/{gameId}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrderItemVm>(cancellationToken);
        return content!;
    }
    public async Task<OrderItemVm> GetAccountCurrentUnusedOrder(int gameId, DateTime openSchedule, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/unused/{gameId}/current?openschedule={openSchedule.ToString("s").Replace(":", "%3A")}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Connecting to core api was unsuccessful.");

        var content = await response.Content.ReadFromJsonAsync<OrderItemVm>(cancellationToken);
        return content!;
    }

    public async Task<AddOrderResponse> AddAccountOrder(AddAccountOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);

            _logger.LogError(errorContent);

            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AddOrderResponse>();
        return content!;
    }

    public async Task UseOrderItemInSchedule(UseOrderItemRequest request, CancellationToken cancellationToken)
    {
        var requestList = new
        {
            ScheduleOrderItems = new List<UseOrderItemRequest>()
            {
                request
            }
        };

        var response = await _client.PostAsJsonAsync("api/order/schedule", requestList, cancellationToken);

        // TODO: there should be a fail handler for this
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Failed to tagged order items to used!. Order Item Ids {string.Join(',', request.OrderItems)}");
        }
    }

    public async Task RevertOrderItem(UseOrderItemRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order/schedule/revert", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task AdvanceScheduleOrder(AdvanceScheduleOrderItemRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order/schedule/advance", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<OrderItemVm> GetOrderItems(GetOrderItemsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/order/items", request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<OrderItemVm>();
        return content!;
    }

    public async Task<OrderItemResponse> GetOrderItemById(long orderItem, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/order/item/detail/{orderItem}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new OrderItemResponse();
        }

        var content = await response.Content.ReadFromJsonAsync<OrderItemResponse>();
        return content!;
    }

    public async Task DeleteOrder(long orderId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync($"api/order/{orderId}", cancellationToken);

        response.EnsureSuccessStatusCode();
    }
    #endregion

    #region Withdrawal
    public async Task<object> GetWithdrawalDetail(long transactionId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/withdrawal/details/{transactionId}", cancellationToken);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<WithdrawalVmResponse> GetCurrentAccountWithdrawals(GetCurrentAccountWithdrawalsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/withdrawal/account/current", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);

            return new WithdrawalVmResponse([]);
        }

        var content = await response.Content.ReadFromJsonAsync<ApiBaseResponse<WithdrawalVmResponse>>(cancellationToken);
        return content!.Data;
    }

    public async Task<AccountWithdrawalResponse> CreateAccountWithdrawal(CreateAccountWithdrawalRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/withdrawal", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);

            return new AccountWithdrawalResponse
            {
                Success = false,
                ErrorMessage = $"Failed to create withdrawal request with Status Code: {response.StatusCode}"
            };
        }

        var content = await response.Content.ReadFromJsonAsync<AccountWithdrawalResponse>(cancellationToken);
        return content!;
    }

    public async Task UpdateWithdrawalStatus(UpdateWithdrawalStatusRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/withdrawal/status", request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
    #endregion

    #region Profile
    public async Task<UserDetailsResponse> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/user/{userId}", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<UserDetailsResponse>();
        return content!;
    }

    public async Task<object> UpdateProofInfo(UpdateProofInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/proof/info", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception(errorContent);
        }

        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> UpdatePersonalDetails(UpdatePersonalDetailsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/personal/details", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> UpdateAddress(UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/address", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> UpdateProfession(UpdateProfessionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/profession", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }

    public async Task<object> UpdateProfileImage(UpdateProfileImageRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/user/profile/image", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<object>();
        return content!;
    }
    #endregion

    #region Upload Image
    public async Task<UploadFileResponse> UploadImage(IFormFile fileRequest, CancellationToken cancellationToken)
    {
        var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(fileRequest.OpenReadStream());
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(fileRequest.ContentType);

        content.Add(fileContent, "file", fileRequest.FileName);

        var response = await _client.PostAsync($"api/upload", content, cancellationToken);

        var respContent = await response.Content.ReadFromJsonAsync<UploadFileResponse>();
        return respContent!;
    }

    public async Task<UploadFileResponse> UploadBase64Image(UploadStringImage request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/upload/base64image", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<UploadFileResponse>();
        return content!;
    }

    public async Task<UploadFileResponse> GetImageByName(string fileName, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/upload/{fileName}", cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<UploadFileResponse>();
        return content!;
    }
    #endregion

    // #region Faq
    // public async Task<T> SearchFaq<T>(SearchFaqRequest request, CancellationToken cancellationToken) where T : class
    // {
    //     var response = await _client.PostAsJsonAsync($"api/faq/search", request, cancellationToken);
    //     if (!response.IsSuccessStatusCode)
    //     {
    //         var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
    //         _logger.LogError(errMessage);

    //         return null;
    //     }

    //     var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
    //     return content!;
    // }
    // #endregion

    #region Notification
    public async Task PostAccountNotification(NotificationInfoRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/notification", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);
        }
    }

    public async Task PostAccountNotificationList(NotificationListRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/notification/list", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);
        }
    }

    public async Task PostNotificationByNameRequest(NotificationByNameRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/notification/generate/account/list", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogError(errMessage);
        }
    }

    public async Task<GetNotificationListResponse> GetSearchNotifications(NotificationSearchRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync("api/notification/search", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<GetNotificationListResponse>();
        return content!;
    }

    public async Task<MarkAllAsReadResponse> MarkAllReadNotification(MarkAllReadRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/notification/mark-all", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<MarkAllAsReadResponse>();
        return content!;
    }
    public async Task<NotificationVm> UpdateNotification(UpdateNotificationRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync("api/notification", request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<NotificationVm>();
        return content!;
    }

    #endregion

    #region Limits

    public async Task<AdminExclusionResponse> GetAccountAdminExclusion(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/administrative/exclusion/account/{accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AdminExclusionResponse>(cancellationToken);
        return content!;
    }

    public async Task<AccountAdminLimitResponse> GetAccountAdminLimitResponse(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/administrative/account/limit/{accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<AccountAdminLimitResponse>(cancellationToken);
        return content!;
    }

    public async Task<SelfLimitResponse> GetSelfLimitExclusion(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/administrative/self-limit/account/{accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<SelfLimitResponse>(cancellationToken);
        return content!;
    }
    #endregion

    #region Livestream
    public async Task<object> GetLatestLivestream(int companyId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/livestream/{companyId}/latest", cancellationToken);
        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }
    #endregion

    #region Announcement
    public async Task<object> GetActiveAnnouncements(ActiveAnnouncementsRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/announcement/active", request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);
        return content!;
    }
    #endregion

    #region Self Exclusion

    public async Task<SelfExclusionVmResponse> GetActiveExlusion(long accountId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync($"api/selfExclusion?AccountId={accountId}", cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<SelfExclusionVmResponse>(cancellationToken);
        return content!;
    }

    public async Task<SelfExclusionVmResponse> CreateSelfExclusion(SelfExclusionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync($"api/selfExclusion", request, cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<SelfExclusionVmResponse>(cancellationToken);
        return content!;
    }

    public async Task<SelfExclusionVmResponse> UpdateActiveExclusion(SelfExclusionRequest request, CancellationToken cancellationToken)
    {
        var response = await _client.PatchAsJsonAsync($"api/selfExclusion", request, cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadFromJsonAsync<SelfExclusionVmResponse>(cancellationToken);
        return content!;
    }
    #endregion
}