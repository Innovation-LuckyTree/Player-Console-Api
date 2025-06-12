using HP_Player_Console.Infrastructure.Core.Models.Responses.Company;
using MediatR;

namespace HP_Player_Console.Application.Requests.Limits.Queries.GetWalletLimit;

public class GetWalletLimitQuery : IRequest<CompanyWalletSettingsResponse>
{
}
