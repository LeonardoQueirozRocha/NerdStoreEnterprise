using NSE.Catalog.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("appsettings.json", true, true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                     .AddEnvironmentVariables();

if (builder.Environment.IsProduction())
    builder.Configuration.AddUserSecrets<StartupBase>();

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddServices();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(builder.Environment);

app.Run();
