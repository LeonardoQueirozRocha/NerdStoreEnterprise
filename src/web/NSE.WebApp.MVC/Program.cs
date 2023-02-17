using NSE.WebApp.MVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("appsettings.json", true, true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                     .AddEnvironmentVariables();

if (builder.Environment.IsProduction())
    builder.Configuration.AddUserSecrets<StartupBase>();

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration(builder.Configuration);

builder.Services.AddServices();

var app = builder.Build();

app.UseMvcConfiguration(app.Environment);

app.Run();
