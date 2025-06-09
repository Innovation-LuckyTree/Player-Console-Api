using HP_Player_Console.API.Controller;
using HP_Player_Console.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

[AllowAnonymous]
[Route("api")]
public class AddressController(ILogger<AddressController> logger, IAddressServicesApi addressServicesApi) : ApiBaseController
{
    private readonly ILogger<AddressController> _logger = logger;
    private readonly IAddressServicesApi _addressServicesApi = addressServicesApi;

    [HttpGet("regions")]
    public async Task<IActionResult> GetRegions(CancellationToken cancellationToken)
    {
        var result = await _addressServicesApi.GetRegions(cancellationToken);
        return Ok(result);
    }

    [HttpGet("regions/{regionCode}/provinces")]
    public async Task<IActionResult> GetProvince(string regionCode, CancellationToken cancellationToken)
    {
        var result = await _addressServicesApi.GetProvince(regionCode, cancellationToken);
        return Ok(result);
    }

    [HttpGet("regions/{regionCode}/cities")]
    public async Task<IActionResult> GetCitiesByRegion(string regionCode, CancellationToken cancellationToken)
    {
        var result = await _addressServicesApi.GetCitiesByRegion(regionCode, cancellationToken);
        return Ok(result);
    }

    [HttpGet("provinces/{provinceCode}/cities-municipalities")]
    public async Task<IActionResult> GetCitiesByMunicipalities(string provinceCode, CancellationToken cancellationToken)
    {
        var result = await _addressServicesApi.GetCitiesAndMunicipalitiesByProvince(provinceCode, cancellationToken);
        return Ok(result);
    }

    [HttpGet("cities-municipalities/{municipalityCode}/barangays")]
    public async Task<IActionResult> GetBarangaysByMunicipalityCode(string municipalityCode, CancellationToken cancellationToken)
    {
        var result = await _addressServicesApi.GetBarangayByMunicipality(municipalityCode, cancellationToken);
        return Ok(result);
    }
}
