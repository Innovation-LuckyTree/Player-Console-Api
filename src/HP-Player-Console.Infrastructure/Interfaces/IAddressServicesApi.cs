namespace HP_Player_Console.Infrastructure.Interfaces;

public interface IAddressServicesApi
{
    Task<object> GetRegions(CancellationToken cancellationToken);
    Task<object> GetProvince(string regionCode, CancellationToken cancellationToken);
    Task<object> GetCitiesByRegion(string regionCode, CancellationToken cancellationToken);
    Task<object> GetCitiesAndMunicipalitiesByProvince(string provinceCode, CancellationToken cancellationToken);
    Task<object> GetBarangayByMunicipality(string municipalityCode, CancellationToken cancellationToken);
}
