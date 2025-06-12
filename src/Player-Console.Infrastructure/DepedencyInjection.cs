using HappyPlay.Infrastructure.AddressServices;
using HP_Player_Console.Infrastructure.AccountServices;
using HP_Player_Console.Infrastructure.Core;
using HP_Player_Console.Infrastructure.CoreIdentity;
using HP_Player_Console.Infrastructure.Helpers;
using HP_Player_Console.Infrastructure.HubClient;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.PaymentServices;
using Microsoft.Extensions.DependencyInjection;

namespace HP_Player_Console.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddTransient<IdentityBearerTokenHandler>();

        services.AddHttpClient<ICoreIdentityApi, CoreIdentityApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler);

        services.AddHttpClient<IAccountServiceApi, AccountServiceApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

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

        services.AddHttpClient<IPaymentServicesApi, PaymentServicesApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

        services.AddHttpClient<ISupportClientApi, SupportClientApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler)
            .AddHttpMessageHandler<IdentityBearerTokenHandler>();

        services.AddHttpClient<IHubClientApi, HubClientApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler);

        services.AddHttpClient<IAddressServicesApi, AddressServicesApi>()
            .ConfigurePrimaryHttpMessageHandler(PrimaryHttpClientHandlerFactory.CreateHttpClientHandler);

        return services;
    }
}
