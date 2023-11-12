using Autofac.Extensions.DependencyInjection;
using Jookli.Api.Configuration.AWS;
using Microsoft.AspNetCore.Hosting;

namespace Jookli.Api
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration(async (hostbuilder, builder) =>
                {
                    var configuration =  AWSConfigurator.ConfigureBuilderAsync(builder).Result;
                });
                webBuilder.UseStartup<Startup>();
                webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
            });
        }
    }
}