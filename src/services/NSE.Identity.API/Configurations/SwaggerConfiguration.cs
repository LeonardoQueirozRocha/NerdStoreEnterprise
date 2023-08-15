using Microsoft.OpenApi.Models;

namespace NSE.Identity.API.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NerdStore Enterprise Identity API",
                Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications",
                Contact = new OpenApiContact { Name = "Leonardo Queiroz Rocha", Email = "contato@desenvolvedor.io" },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(option =>
        {
            option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        return app;
    }
}