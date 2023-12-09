using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Validation;
using Jookli.Api.Configuration.Authorization;
using Jookli.Api.Configuration.ExecutionContext;
using Jookli.Api.Configuration.Extensions;
using Jookli.Api.Modules.Payments;
using Jookli.Api.Modules.UserAccess;
using Jookli.BuildingBlocks.Application;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Commander.Infrastructure;
using Jookli.Commander.Infrastructure.Configuration;
using Jookli.Games.Infrastructure;
using Jookli.Games.Infrastructure.Configuration;
using Jookli.Payments.Infrastructure;
using Jookli.Payments.Infrastructure.Configuration;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Application.IdentityServer;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Infrastructure;
using Jookli.UserAccess.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;

namespace Jookli.Api
{
    public class Startup
    {
        private const string JookliConnectionString = "JookliConnectionString";
        private const string StripeSecret = "StripeSecret";
        private readonly IConfiguration _configuration;
        private static Serilog.ILogger _logger;
        private static Serilog.ILogger _apiLogger;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            ConfigureLogger();

            _configuration = configuration;
            _apiLogger.Information("Connection string: " + _configuration[JookliConnectionString]);
            _apiLogger.Information("Stripe secret: " + _configuration[StripeSecret]);

            AuthorizationChecker.CheckAllEndpoints();

            _apiLogger.Information("Connected");
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
            options.UseSqlServer(_configuration[JookliConnectionString], x => x.MigrationsHistoryTable("__UserAccessMigrationsHistory", "dbo"));
            });

            services.AddDbContext<GamesContext>(options =>
            {
                options.UseSqlServer(_configuration[JookliConnectionString], x => x.MigrationsHistoryTable("__GamesMigrationsHistory","dbo"));
            });

            services.AddDbContext<PaymentsContext>(options =>
            {
                options.UseSqlServer(_configuration[JookliConnectionString], x => x.MigrationsHistoryTable("__PaymentsMigrationsHistory", "dbo"));
            });

            services.AddDbContext<CommanderContext>(options =>
            {
                options.UseSqlServer(_configuration[JookliConnectionString], x => x.MigrationsHistoryTable("__CommanderMigrationsHistory", "dbo"));
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
            containerBuilder.RegisterModule(new PaymentsAutofacModule());
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

            var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

            UserAccessStartup.Initialize(
                _configuration[JookliConnectionString],
                executionContextAccessor,
                _logger,
                emailsConfiguration,
                _configuration["Security:TextEncryptionKey"],
                null,
                null);

            PaymentsStartup.Initialize(_configuration[JookliConnectionString],
                executionContextAccessor,
                _logger,
                null,
                null);

            GamesStartup.Initialize(_configuration[JookliConnectionString],
                executionContextAccessor,
                _logger,
                null,
                null);

            CommanderStartup.Initialize(_configuration[JookliConnectionString],
                executionContextAccessor,
                _logger,
                null,
                null);
        }
    }
}
