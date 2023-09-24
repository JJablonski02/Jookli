using Jookli.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Api
{
    public class Startup
    {
        public void  ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddEndpointsApiExplorer();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment, IServiceProvider provider)
        {
            app.UseStaticFiles();
           

            if (!webHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
