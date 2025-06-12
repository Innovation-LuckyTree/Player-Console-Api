using HP_Player_Console.Infrastructure.Core.Models.Requests.SelfExclusion;
using HP_Player_Console.Infrastructure.Core.Models.Responses.SelfExclusion;
using MediatR;

namespace HP_Player_Console.Requests.SelfExclusion.Commands.UpdateActiveExclusion;

public record UpdateActiveExclusionCommand(SelfExclusionRequest request) : IRequest<SelfExclusionVmResponse>;