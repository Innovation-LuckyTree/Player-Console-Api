using MediatR;

namespace HP_Player_Console.Application.Requests.Users.Commands.BasicRegistration;

public class BasicRegistrationCommand : IRequest<object>
{
    public string UserName { get; set; }
    public string MobileNumber { get; set; }
    public string? ReferralCode { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

