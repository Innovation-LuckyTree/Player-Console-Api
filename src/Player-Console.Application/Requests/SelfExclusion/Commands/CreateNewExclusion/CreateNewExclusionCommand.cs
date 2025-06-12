using HP_Player_Console.Infrastructure.Core.Models.Requests.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using MediatR;

namespace HP_Player_Console.Requests.SelfExclusion.Commands.CreateNewExclusion;

public record CreateNewExclusionCommand(SelfExclusionRequest request) : IRequest<SelfExclusionVmResponse>;