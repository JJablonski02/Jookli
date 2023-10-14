using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jookli.Api.Configuration.Authorization;
using Jookli.Api.Configuration.ExecutionContext;
using Jookli.Api.Configuration.Extensions;
using Jookli.Api.Modules.UserAccess;
using Jookli.BuildingBlocks.Application;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Infrastructure;
using Jookli.UserAccess.Infrastructure.Configuration;
using Jookli.UserAccess.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Compact;

namespace Jookli.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private static Serilog.ILogger _logger;

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

            services.AddSwaggerDocumentation();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            services.AddDbContext<UserAccessContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(HasPermissionAttribute.HasPermissionPolicyName, policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement());
                });
            });

            services.AddScoped<IAuthorizationHandler, HasPermissionAuthorizationHandler>();
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
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            InitializeModules(container);

            app.UseMiddleware<CorrelationMiddleware>();

            app.UseSwaggerDocumentation();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            if (!webHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0");
            //    options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2.0");
            //}); // creates swagger UI for tesing all web API endpoints / action methods 

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

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

        private void ConfigureIdentityServer(IServiceCollection services)
        {
        }

        private void InitializeModules(ILifetimeScope containerLifeTime)
        {
            var httpContextAccessor = containerLifeTime.Resolve<IHttpContextAccessor>();
            var executeContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

            UserAccessStartup.Initialize(connectionString: _configuration.GetConnectionString("DefaultConnection"), logger: _logger, executeContextAccessor);
        }
    }
}
