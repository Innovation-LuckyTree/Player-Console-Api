using HP_Player_Console.Common.Enums;

namespace HP_Player_Console.Common.Models
{
    public class AccountModel
    {
        public Guid AccountObjId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public AccountTypes AccountType { get; set; }
    }
}
