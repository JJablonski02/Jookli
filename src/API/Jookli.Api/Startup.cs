using Amazon;
using Amazon.Extensions.Configuration.SystemsManager;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Validation;
using Jookli.Api.Configuration.Authorization;
using Jookli.Api.Configuration.ExecutionContext;
using Jookli.Api.Configuration.Extensions;
using Jookli.Api.Modules.UserAccess;
using Jookli.BuildingBlocks.Application;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Application.IdentityServer;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Infrastructure;
using Jookli.UserAccess.Infrastructure.Configuration;
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
        private const string JookliConnectionString = "JookliConnectionString";
        private readonly IConfiguration _configuration;
        private static Serilog.ILogger _logger;
        private static Serilog.ILogger _apiLogger;

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            ConfigureLogger();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _apiLogger.Information("Connection string: " + _configuration[JookliConnectionString]);
            AuthorizationChecker.CheckAllEndpoints();
            _apiLogger.Information("Connected");
        }

        public async Task<IConfiguration> ConfigurationBuilder(IWebHostEnvironment webHostEnvironment)
        {
            var environment = webHostEnvironment.EnvironmentName.ToLower();

            var builder = new ConfigurationBuilder();
            var credentials = new BasicAWSCredentials("AKIAVPZBIZMAI4VKQG65", "gekwQkM4581dhsJDHtBq9a7xMYK4EGcFL2R9PYmF");
            var client = new AmazonSimpleSystemsManagementClient(credentials, RegionEndpoint.EUNorth1);

            var request = new GetParameterRequest()
            {
                Name = $"/{environment}/JookliApi/ConnectionString"
            };

            var value = await client.GetParameterAsync(request: request);

            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            _apiLogger.Information("Connection string: " + configuration[JookliConnectionString]);
            AuthorizationChecker.CheckAllEndpoints();
            _apiLogger.Information("Connected");

            return configuration;
        }

        public void  ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerDocumentation();

            ConfigureIdentityServer(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            services.AddDbContext<UserAccessContext>(options =>
            {
                options.UseSqlServer(_configuration[JookliConnectionString]);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(HasPermissionAttribute.HasPermissionPolicyName, policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement());
                    policyBuilder.AddAuthenticationSchemes(IdentityServerAuthenticationDefaults.AuthenticationScheme);
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

            app.UseDefaultFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "*");
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Methods", "*");
                },
            });

            InitializeModules(container);

            app.UseMiddleware<CorrelationMiddleware>();

            app.UseSwaggerDocumentation();

            app.UseIdentityServer();

            if (!webHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

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

            _apiLogger = _logger.ForContext("Module", "API");
            _apiLogger.Information("Logger configured");
        }

        private void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApis())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddInMemoryPersistedGrants()
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, x =>
                {
                    x.Authority = "http://localhost:5107";
                    x.ApiName = "JookliAPI";
                    x.RequireHttpsMetadata = false;
                });
        }

        private void InitializeModules(ILifetimeScope containerLifeTime)
        {
            var httpContextAccessor = containerLifeTime.Resolve<IHttpContextAccessor>();
            var emailsConfiguration = new EmailsConfiguration(_configuration["EmailsConfiguration:FromEmail"]);

            var executeContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

            UserAccessStartup.Initialize(connectionString: _configuration[JookliConnectionString], logger: _logger, executeContextAccessor);
        }
    }
}
