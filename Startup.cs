using FinanceProject_WebApp_1_1.DbContexts;
using FinanceProject_WebApp_1_1.Repositories;
using FinanceProject_WebApp_1_1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Auth0.AspNetCore.Authentication;

namespace FinanceProject_WebApp_1_1
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<FinanceDBContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("FinanceAppConnString"))); 
            services.AddScoped<ITickerRepository, TickerRepository>();
            services.AddScoped<ITickerService, TickerService>();
            services.AddAuth0WebAppAuthentication(options => {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
                options.Scope = "openid profile email";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ticker}/{action=Index}/{id?}");
            });
        }
    }
}
