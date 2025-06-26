namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts
{
    public class BasicVerificationRequest
    {
        public Guid AccountObjectId { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string NatureOfWork { get; set; }
        public string SourceOfIncome { get; set; }
        public string BirthDate { get; set; }
        public int? SalaryRange { get; set; }

        public string FrontIdPath { get; set; }
        public string SelfiePath { get; set; }
        public string BackIdPath { get; set; }
    }
}
