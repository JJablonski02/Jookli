using Autofac.Extensions.DependencyInjection;

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
            return Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
            });
        }
    }
}