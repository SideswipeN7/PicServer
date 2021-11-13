﻿using Pic.Data.DI;
using Pic.Logic.DI;

namespace Pic.Service.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        builder.Host.AddConfigurationFiles();

        return builder;
    }

    public static WebApplicationBuilder RegisterServicesAndDI(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        DataModule.Register(configuration, services);
        LogicModule.Register(services);

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Pic.Service", Version = "v1" });
        });

        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "..\\Pic.Client";
        });

        return builder;
    }
}