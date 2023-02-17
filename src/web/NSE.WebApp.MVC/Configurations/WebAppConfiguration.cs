using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Configurations
{
    public static class WebAppConfiguration
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.Configure<AppSettings>(configuration);
        }

        public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/error/500");
            //    app.UseStatusCodePagesWithRedirects("/error/{0}");
            //    app.UseHsts();
            //}

            app.UseExceptionHandler("/error/500");
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });            
        }
    }
}
