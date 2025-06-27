using HP_Player_Console.Infrastructure.Core.Models.Requests.Announcements;
using HP_Player_Console.Infrastructure.Core.Models.Requests.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Requests.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Company;
using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Limits;
using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using HP_Player_Console.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface ICoreApi
{
    Task<ApiBaseResponse<CompanyResponse>> GetCompanyById(string companyid, CancellationToken cancellationToken);
    Task<CompanyWalletSettingsResponse> GetWalletSettings(int companyId, CancellationToken cancellationToken);
    Task<UploadFileResponse> UploadImage(IFormFile fileRequest, CancellationToken cancellationToken);
    Task<UploadFileResponse> UploadBase64Image(UploadStringImage request, CancellationToken cancellationToken);
    Task<UploadFileResponse> GetImageByName(string fileName, CancellationToken cancellationToken);
    Task<AdminExclusionResponse> GetAccountAdminExclusion(long accountId, CancellationToken cancellationToken);
    Task<AccountAdminLimitResponse> GetAccountAdminLimitResponse(long accountId, CancellationToken cancellationToken);
    Task<SelfLimitResponse> GetSelfLimitExclusion(long accountId, CancellationToken cancellationToken);
    Task<object> GetLatestLivestream(int companyId, CancellationToken cancellationToken);
    Task<object> GetActiveAnnouncements(ActiveAnnouncementsRequest request, CancellationToken cancellationToken);
    Task<SelfExclusionVmResponse> GetActiveExlusion(long accountId, CancellationToken cancellationToken);
    Task<SelfExclusionVmResponse> CreateSelfExclusion(SelfExclusionRequest request, CancellationToken cancellationToken);
    Task<SelfExclusionVmResponse> UpdateActiveExclusion(SelfExclusionRequest request, CancellationToken cancellationToken);
    Task<object> GetGameCategories(CancellationToken cancellationToken);
    Task<object> GetProviderByCategoryId(int categoryId, CancellationToken cancellationToken);
    Task<object> GetGamesByCategoryAndProvider(int categoryId, int providerId, int pageNumber, int pageSize, CancellationToken cancellationToken);
}
