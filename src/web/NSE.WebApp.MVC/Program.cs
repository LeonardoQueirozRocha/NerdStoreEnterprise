using NSE.WebApp.MVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration();

var app = builder.Build();

app.UseMvcConfiguration(app.Environment);

app.Run();
