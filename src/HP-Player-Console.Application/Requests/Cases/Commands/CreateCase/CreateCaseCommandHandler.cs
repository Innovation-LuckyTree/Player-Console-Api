using AutoMapper;
using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Support.Requests;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Commands.CreateCase;

public class CreateCaseCommandHandler(ISupportClientApi supportApi, ICoreAccountApi coreAccountApi, ICurrentUserService currentUser) : IRequestHandler<CreateCaseCommand, object>
{
    private readonly ISupportClientApi _supportApi = supportApi;
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;
    private readonly ICurrentUserService _currentUser = currentUser;

    public async Task<object> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
    {
        var accountInfo = await _coreAccountApi.AccountCurrent(cancellationToken);

        Owner owner = new()
        {
            UserId = accountInfo.UserId.ToString(),
            MobileNumber = accountInfo.MobileNumber,
            FirstName = accountInfo.FirstName,
            LastName = accountInfo.LastName,
            MiddleName = accountInfo.MiddleName,
            Email = accountInfo.Email ?? ""
        };

        return await _supportApi.CreateCase(new CreateCaseRequest
        {
            Title = request.Title,
            Owner = owner,
            Description = request.Description,
            Attachments = request.Attachments,
            TicketDate = DateTime.Now,
            CategoryId = request.CategoryId,
            CompanyId = Guid.Parse(_currentUser.CompanyId),
            PriorityLevel = PriorityLevels.Low,
            BranchId = accountInfo.BranchId,
            Comment = request.Comment
        }, cancellationToken);
    }
}
