﻿using Autofac.Extensions.DependencyInjection;
using Jookli.Application.Features.User.Register.Command;
using Jookli.Application.ServiceContracts;
using Jookli.Infrastructure.Data;
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

            services.AddDbContext<ApplicationDbContext>(options =>
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

            //services.AddScoped<IUserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment, IServiceProvider provider)
        {

            var autofacRoot = app.ApplicationServices.GetAutofacRoot();

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:61385", "https://localhost:7133", "http://localhost:5107").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0");
            });

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
    }
}
