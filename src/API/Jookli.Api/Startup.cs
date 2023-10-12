using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jookli.Api.Modules.Module;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Infrastructure;
using Jookli.UserAccess.Infrastructure.Configuration;
using Jookli.UserAccess.Infrastructure.Data;
using Jookli.UserAccess.Infrastructure.Domain.User;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;

namespace Jookli.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private static Serilog.ILogger _logger;
        private static IContainer _container;

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            ConfigureLogger();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                //.AddEnvironmentVariables("_Jookli")
                .Build();


            _logger.Information("Connection string: " + _configuration.GetConnectionString("DefaultConnection"));
        }
        public void  ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(config =>
            {
                config.ApiVersionReader = new UrlSegmentApiVersionReader(); // Reads version number from request url at "apiVersion" constraint

                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddDbContext<UserAccessContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddEndpointsApiExplorer(); //Generates description for all endpoints

            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Jookli API", Version = "1.0" });
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl= true;
            });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new UserAccessAutofacModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment, IServiceProvider provider)
        {

            var container = app.ApplicationServices.GetAutofacRoot();

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:61385", "https://localhost:7133", "http://localhost:5107").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            app.UseDefaultFiles();

            app.UseStaticFiles();

            InitializeModules(container);

            if (!webHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureLogger()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.RollingFile(new CompactJsonFormatter(), "logs/logs")
                .CreateLogger();
        }

        private void InitializeModules(ILifetimeScope containerLifeTime)
        {
            UserAccessStartup.Initialize(connectionString: _configuration.GetConnectionString("DefaultConnection"), logger: _logger);
        }
    }
}
