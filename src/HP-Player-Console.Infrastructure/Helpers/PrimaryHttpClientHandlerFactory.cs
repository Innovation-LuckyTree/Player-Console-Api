using System.Security.Authentication;

namespace HP_Player_Console.Infrastructure.Helpers
{
    public class PrimaryHttpClientHandlerFactory
    {
        public static HttpClientHandler CreateHttpClientHandler() => new HttpClientHandler { SslProtocols = SslProtocols.Tls12 };
    }
}
