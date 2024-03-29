using MediatR;
using NSE.Orders.API.Configuration;
using NSE.WebApi.Core.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("appsettings.json", true, true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                     .AddEnvironmentVariables();

if (builder.Environment.IsProduction())
    builder.Configuration.AddUserSecrets<StartupBase>();

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(typeof(StartupBase));

builder.Services.AddServices();

builder.Services.AddMessageBusConfiguration(builder.Configuration);

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(builder.Environment);

app.Run();
