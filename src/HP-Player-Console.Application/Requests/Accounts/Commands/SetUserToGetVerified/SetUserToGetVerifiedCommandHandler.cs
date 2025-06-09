using HP_Player_Console.Application.Common.Exceptions;
using HP_Player_Console.Common.Models;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.SetUserToGetVerified;

public class SetUserToGetVerifiedCommandHandler(ICoreAccountApi coreApi, ILogger<SetUserToGetVerifiedCommandHandler> logger) : IRequestHandler<SetUserToGetVerifiedCommand, ApiResponseBase<bool>>
{
    private readonly ICoreAccountApi _coreApi = coreApi;
    private readonly ILogger<SetUserToGetVerifiedCommandHandler> _logger = logger;

    public async Task<ApiResponseBase<bool>> Handle(SetUserToGetVerifiedCommand request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreApi.AccountCurrent(cancellationToken);

        try
        {
            var result = await _coreApi.SetAccountToForVerification(new ForVerificationRequest(accountInfo.AccountObjectId), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to set user to for Verification!");    
            throw new BadRequestBaseException("Failed to set account status to For Verification!")
            {
                ErrorCode = "401"
            };
        }

        return new ApiResponseBase<bool>()
        {
            Success = true,
            Data = true
        };
    }
}