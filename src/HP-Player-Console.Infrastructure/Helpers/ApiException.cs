using System.Net;

namespace HP_Player_Console.Infrastructure.Helpers
{
    public class ApiException : HttpRequestException
    {
        public ApiException(string api, string body, string? message, Exception? inner, HttpStatusCode? statusCode)
            : base(message, inner, statusCode)
            => (Api, Body) = (api, body);

        public string Api { get; private set; }
        public string Body { get; private set; }
    }
}
