using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Core.Models.Requests.OTP;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;
using HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Profiles;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Withdrawals;
using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface ICoreAccountApi
{
    Task<CurrentAccountResponse> AccountCurrent(CancellationToken cancellationToken);
    Task<PlayersAgentResponse> GetPlayerAgentInfo(CancellationToken cancellationToken);
    Task<FindPlayerResponse> FindPlayer(FindPlayerRequest request, CancellationToken cancellationToken);
    Task UpdateUserPassword(UpdateUserPasswordRequest request, CancellationToken cancellationToken);
    Task<ProviderAccountResponse> SetProviderAccount(CancellationToken cancellationToken);
    Task<bool> SetAccountToForVerification(ForVerificationRequest request, CancellationToken cancellationToken);
    Task<AccountBonusResponse> GetAccountBonus(AccountBonusRequest request, CancellationToken cancellationToken);
    Task<OtpResponse> GenerateOTP(string mobileNumber, CancellationToken cancellationToken);
    Task<ApiBaseResponse<object>> VerifyOTP(VerifyOtpRequest request, CancellationToken cancellationToken);
    Task<object> GetWithdrawalDetail(long transactionId, CancellationToken cancellationToken);
    Task<WithdrawalVmResponse> GetCurrentAccountWithdrawals(GetCurrentAccountWithdrawalsRequest request, CancellationToken cancellationToken);
    Task<AccountWithdrawalResponse> CreateAccountWithdrawal(CreateAccountWithdrawalRequest request, CancellationToken cancellationToken);
    Task UpdateWithdrawalStatus(UpdateWithdrawalStatusRequest request, CancellationToken cancellationToken);
    Task<UserDetailsResponse> GetUserById(Guid userId, CancellationToken cancellationToken);
    Task<object> UpdateProofInfo(UpdateProofInfoRequest request, CancellationToken cancellationToken);
    Task<object> UpdatePersonalDetails(UpdatePersonalDetailsRequest request, CancellationToken cancellationToken);
    Task<object> UpdateAddress(UpdateAddressRequest request, CancellationToken cancellationToken);
    Task<object> UpdateProfession(UpdateProfessionRequest request, CancellationToken cancellationToken);
    Task<object> UpdateProfileImage(UpdateProfileImageRequest request, CancellationToken cancellationToken);
    Task<object> BasicUserRegistration(BasicUserRegistration request, CancellationToken cancellationToken);
}
