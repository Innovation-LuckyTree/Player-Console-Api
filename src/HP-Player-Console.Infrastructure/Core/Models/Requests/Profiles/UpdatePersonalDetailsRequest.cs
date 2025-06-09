namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;

public class UpdatePersonalDetailsRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public string MartialStatus { get; set; }
    public string Nationality { get; set; }
    public string BirthDate { get; set; }
    public string PlaceOfBirth { get; set; }
}