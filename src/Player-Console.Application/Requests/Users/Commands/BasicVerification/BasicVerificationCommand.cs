using HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Users.Commands.BasicVerification
{
    public class BasicVerificationCommand : IRequest<object>
    {
        public Guid AccountObjectId { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string NatureOfWork { get; set; }
        public string SourceOfIncome { get; set; }
        public string BirthDate { get; set; }
        public int? SalaryRange { get; set; }

        public string FrontIdPath { get; set; }
        public string SelfiePath { get; set; }
        public string BackIdPath { get; set; }
    }

    public class BasicVerificationCommandHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<BasicVerificationCommand, object>
    {
        private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

        public async Task<object> Handle(BasicVerificationCommand request, CancellationToken cancellationToken)
        {
            return await _coreAccountApi.BasicVerification(new BasicVerificationRequest
            {
                AccountObjectId = request.AccountObjectId,
                MobileNumber = request.MobileNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Suffix = request.Suffix,
                NatureOfWork = request.NatureOfWork,
                SourceOfIncome = request.SourceOfIncome,
                BirthDate = request.BirthDate,
                SalaryRange = request.SalaryRange,
                FrontIdPath = request.FrontIdPath,
                SelfiePath = request.SelfiePath,
                BackIdPath = request.BackIdPath
            }, cancellationToken);
        }
    }
}
