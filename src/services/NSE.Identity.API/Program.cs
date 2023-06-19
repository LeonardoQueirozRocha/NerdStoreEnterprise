using NSE.Identity.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("appsettings.json", true, true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                     .AddEnvironmentVariables();

if (builder.Environment.IsProduction()) 
    builder.Configuration.AddUserSecrets<StartupBase>();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddMessageBusConfiguration(builder.Configuration);

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

app.Run();
