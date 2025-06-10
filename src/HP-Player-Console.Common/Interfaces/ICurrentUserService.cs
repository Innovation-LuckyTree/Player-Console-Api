namespace HP_Player_Console.Common.Interfaces;

public interface ICurrentUserService
{
    string UserId { get; }
    string AuthenticationBearer { get; }
    string CompanyId { get; }
    Guid UserObjId { get; }
    Guid LogId { get; }
}
