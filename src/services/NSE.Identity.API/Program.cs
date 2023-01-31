using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NSE.Identity.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NerdStore Enterprise Identity API",
        Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications",
        Contact = new OpenApiContact { Name = "Leonardo Queiroz Rocha", Email = "contato@desenvolvedor.io" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
