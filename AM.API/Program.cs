using AM.API.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AM.API
{
    //"DefaultConnection": "Data Source=SQL5052.site4now.net;Initial Catalog=DB_A5715B_ptechamdb2;User Id=DB_A5715B_ptechamdb2_admin;Password=jmolesco_06;"
    //"Server=(localdb)\\mssqllocaldb;Initial Catalog=ptech-am-db;Integrated Security=True",
    //"DefaultConnection": "Data Source=SQL5052.site4now.net;Initial Catalog=DB_A5715B_ptechamdb2;User Id=DB_A5715B_ptechamdb2_admin;Password=jmolesco_06;"
    //"Server=(localdb)\\mssqllocaldb;Initial Catalog=ptech-am-db;Integrated Security=True"
    //"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Initial Catalog=ptech-am-db;Integrated Security=True"
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    DBInitializerHelper.CreateDefaultData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating default database records.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       var env = hostingContext.HostingEnvironment;

                       config.AddJsonFile("appsettings.json", optional: true)
                           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                       config.AddEnvironmentVariables();
                   })
                   .UseStartup<Startup>()
                   .Build();
    }
}
