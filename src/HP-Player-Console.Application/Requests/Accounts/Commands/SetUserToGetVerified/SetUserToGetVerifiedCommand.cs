using HP_Player_Console.Common.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Commands.SetUserToGetVerified;

public class SetUserToGetVerifiedCommand : IRequest<ApiResponseBase<bool>>;
