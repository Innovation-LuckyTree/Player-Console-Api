using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Company;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Limits.Queries.GetWalletLimit;

public class GetWalletLimitQueryHandler : IRequestHandler<GetWalletLimitQuery, CompanyWalletSettingsResponse>
{
    private readonly ICoreApi _coreApi;
    private readonly ICoreAccountApi _coreAccountApi;
    private readonly ICurrentUserService _currentUserService;

    public GetWalletLimitQueryHandler(ICurrentUserService currentUserService, ICoreApi coreApi, ICoreAccountApi coreAccountApi)
    {
        _currentUserService = currentUserService;
        _coreApi = coreApi;
        _coreAccountApi = coreAccountApi;

    }

    public async Task<CompanyWalletSettingsResponse> Handle(GetWalletLimitQuery request, CancellationToken cancellationToken)
    {
        var company = await _coreApi.GetCompanyById(_currentUserService.CompanyId, cancellationToken);
        var walletSettings = await _coreApi.GetWalletSettings(company.Data.CompanyId, cancellationToken);

        return walletSettings;
    }
}