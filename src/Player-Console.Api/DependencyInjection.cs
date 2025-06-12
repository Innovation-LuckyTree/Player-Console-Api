using FluentValidation.AspNetCore;
using HP_Player_Console.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using HP_Player_Console.Application;
using HP_Player_Console.API.Attributes;
using HP_Player_Console.API.Services;
using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure;

namespace HP_Player_Console.API;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddAppBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddConfigurations(builder.Configuration);
        builder.Services.AddApplicationLayer();
        builder.Services.AddControllers();
        builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();
        builder.Services.AddInfrastructureLayer();

        builder.Services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "allOrigin",
            policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc("v1", new OpenApiInfo { Title = "HP_Player_Console API", Version = "version 1.0" });

            opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            opts.OperationFilter<FileUploadOperation>();
            opts.OperationFilter<OptionalRouteParameterOperationFilter>();
            opts.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        builder.Services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddFluentValidation();

        builder.Services.AddMemoryCache();


        return builder;
    }
}