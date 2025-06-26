using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Users.Commands.BasicRegistration;

public class BasicRegistrationCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<BasicRegistrationCommand, object>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(BasicRegistrationCommand request, CancellationToken cancellationToken)
    {
        return await _coreAccountApi.BasicUserRegistration(new BasicUserRegistration
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MobileNumber = request.MobileNumber,
            ReferralCode = request.ReferralCode,
            Password = request.Password,
            UserName = request.UserName
        }, cancellationToken);
    }
}
