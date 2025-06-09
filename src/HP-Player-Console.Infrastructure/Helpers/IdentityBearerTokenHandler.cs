using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace HP_Player_Console.Infrastructure.Helpers
{
    public class IdentityBearerTokenHandler : DelegatingHandler
    {
        /// <summary>
        /// The Identity API Client to retrieve the Auth token from.
        /// </summary>
        private readonly ICurrentUserService _currentUserService;
        private readonly IAppConfig _appConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityBearerTokenHandler(ICurrentUserService currentUserService, IAppConfig appConfig, IHttpContextAccessor httpContextAccessor)
        {
            _currentUserService = currentUserService;
            _appConfig = appConfig;
            _httpContextAccessor = httpContextAccessor;

        }

        /// <summary>
        /// If the Authorization header is missing, will call the Identity API and retrieve an auth token.
        /// Adds the Authorization header and then continues the HTTP Request.
        /// </summary>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenBearer = GetTokenBearer();

            request.Headers.Add("Accept", "application/json");
            if (!request.Headers.Contains("Authorization") && !string.IsNullOrEmpty(tokenBearer))
            {
                request.Headers.Add("Authorization", $"{tokenBearer}");
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private string GetTokenBearer()
        {
            if (_httpContextAccessor.HttpContext == null)
                return "";

            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues result))
            {
                if (result.Count > 0)
                {
                    return result[0];
                }
            }

            return "";
        }
    }
}
