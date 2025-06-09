using HP_Player_Console.Infrastructure.Common.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.SetUserToGetVerified;

public class SetUserToGetVerifiedCommand : IRequest<BaseApiResponse<bool>>;
