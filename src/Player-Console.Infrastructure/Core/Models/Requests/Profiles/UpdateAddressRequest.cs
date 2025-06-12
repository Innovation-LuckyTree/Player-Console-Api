namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;

public class UpdateAddressRequest
{
    public string PresentRegion { get; set; }
    public string PresentProvince { get; set; }
    public string PresentMunicipality { get; set; }
    public string PresentBarangay { get; set; }
    public string PresentStreetOrPurok { get; set; }

    public string PermanentRegion { get; set; }
    public string PermanentProvince { get; set; }
    public string PermanentMunicipality { get; set; }
    public string PermanentBarangay { get; set; }
    public string PermanentStreetOrPurok { get; set; }
}