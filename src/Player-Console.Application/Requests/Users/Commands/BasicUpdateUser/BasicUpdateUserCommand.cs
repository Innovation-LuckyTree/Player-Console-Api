using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Users.Commands.BasicUpdateUser
{
    public class BasicUpdateUserCommand : IRequest<object>
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? MartialStatus { get; set; }
        public string? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
    }

    public class BasicUpdateUserCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<BasicUpdateUserCommand, object>
    {
        private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

        public async Task<object> Handle(BasicUpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _coreAccountApi.BasicUserUpdate(new BasicUpdateUserRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                MartialStatus = request.MartialStatus,
                Email = request.Email,
                Gender = request.Gender,    
                UserId = request.UserId,
                MobileNumber = request.MobileNumber,
            }, cancellationToken);
        }
    }
}
