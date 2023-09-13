using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Auth0.AspNetCore.Authentication;

namespace FinanceProject_WebApp_1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        /*   public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();
                   });
           }*/
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration((hostingContext, config) =>
         {
             config.SetBasePath(Directory.GetCurrentDirectory());
             config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             config.AddEnvironmentVariables();
         })
         .UseStartup<Startup>();
    }
}
