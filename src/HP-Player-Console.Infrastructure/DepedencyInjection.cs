using HP_Player_Console.Infrastructure.Core;
using HP_Player_Console.Infrastructure.CoreIdentity;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HP_Player_Console.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddTransient<IdentityBearerTokenHandler>();

        services.AddHttpClient<ICoreIdentityApi, CoreIdentityApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler);

        services.AddHttpClient<ICoreApi, CoreApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

        services.AddHttpClient<ICoreAccountApi, CoreAccountApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

        services.AddHttpClient<ICoreOrderApi, CoreOrderApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

        services.AddHttpClient<ICoreNotificationApi, CoreNotificationApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

        return services;
    }
}
