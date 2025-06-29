namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts
{
    public class BasicUpdateUserRequest
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? MartialStatus { get; set; }
        public string? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
    }
}
