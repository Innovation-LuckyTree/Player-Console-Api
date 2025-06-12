using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Announcements.Queries.GetActiveAnnouncements;

public record GetActiveAnnouncementsQuery(string CompanyId, int BranchId) : IRequest<object>;
