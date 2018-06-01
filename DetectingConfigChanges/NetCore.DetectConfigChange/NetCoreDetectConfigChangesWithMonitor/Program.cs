using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace NetCoreDetectConfigChangesWithMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("version-config.json", false, true)
            //    .Build();

            return WebHost.CreateDefaultBuilder(args)
                //.UseConfiguration(config)
                .ConfigureAppConfiguration((buiderContext, config) => {
                    IHostingEnvironment env = buiderContext.HostingEnvironment;

                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("version-config.json", false, true);
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}
