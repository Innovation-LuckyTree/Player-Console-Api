using HP_Player_Console.Application.Common.Constants;
using HP_Player_Console.Application.Common.Exceptions;
using HP_Player_Console.Common.Interfaces;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HP_Player_Console.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetClaimValueByKey(string key)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext == null)
            return null;

        var nameIdentifier = httpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (httpContext.Request.Headers.TryGetValue("Authorization", out StringValues result))
        {
            if (result.Count < 1)
                throw new UnauthorizedAccessException();

            var bearer = result[0].Replace("Bearer ", "");
            try
            {
                // parse jwt
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(AuthenticationBearer);
                var tokenObject = jsonToken as JwtSecurityToken;

                return tokenObject.Claims.First(c => c.Type == key).Value;
            }
            catch (Exception ex)
            {
                throw new BadRequestBaseException($"Unable to get {key} claim in JWT Token!")
                {
                    ErrorCode = LoginExceptionCodes.INVALID_JWT_TOKEN
                };
            }
        }

        throw new UnauthorizedAccessException();
    }

    public string UserId
    {
        get
        {
            return GetClaimValueByKey("nameid");
        }
    }
    public Guid UserObjId
    {
        get
        {
            return new Guid(GetClaimValueByKey("nameid"));
        }
    }
    public string AuthenticationBearer
    {
        get
        {
            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues result))
            {
                if (result.Count > 0)
                {
                    return result[0].Replace("Bearer ", "");

                }

            }

            return "";
        }
    }

    public string CompanyId
    {
        get
        {
            return GetClaimValueByKey("companyId");
        }
    }
}
