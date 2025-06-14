namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts
{
    public class BasicUserRegistration
    {
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string? ReferralCode { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
