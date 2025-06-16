using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Users.Commands.BasicRegistration
{
    public class BasicRegistrationCommand : IRequest<object>
    {
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string? ReferralCode { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }

    public class BasicRegistrationCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<BasicRegistrationCommand, object>
    {
        private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

        public async Task<object> Handle(BasicRegistrationCommand request, CancellationToken cancellationToken)
        {
            return await _coreAccountApi.BasicUserRegistration(new BasicUserRegistration
            {
                FullName = request.FullName,
                MobileNumber = request.MobileNumber,
                ReferralCode = request.ReferralCode,
                Password = request.Password,
                UserName = request.UserName
            }, cancellationToken);
        }
    }
}
