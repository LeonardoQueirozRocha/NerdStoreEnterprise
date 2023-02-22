using Microsoft.OpenApi.Models;

namespace NSE.Catalog.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Catálogo API",
                    Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications",
                    Contact = new OpenApiContact { Name = "Leonardo Queiroz Rocha", Email = "contato@desenvolvedor.io" },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
