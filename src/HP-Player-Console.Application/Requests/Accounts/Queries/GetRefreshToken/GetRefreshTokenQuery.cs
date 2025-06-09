using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetRefreshToken;

public record GetRefreshTokenQuery(string Token, string RefreshToken) : IRequest<LoginUserResponse>;
