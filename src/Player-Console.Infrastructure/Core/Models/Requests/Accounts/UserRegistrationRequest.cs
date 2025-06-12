namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;

public class UserRegistrationRequest
{
    public string ReferralCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string MobileNumber { get; set; }
}
