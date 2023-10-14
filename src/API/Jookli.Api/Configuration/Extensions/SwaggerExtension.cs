using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Jookli.Api.Configuration.Extensions
{
    internal static class SwaggerExtension
    {
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Jookli API",
                    Version = "v1",
                    Description = "Jookli API for Jookli Native Application"
                });
                options.CustomSchemaIds(t => t.ToString());

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                options.IncludeXmlComments(commentsFile);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference
                           {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer"
                           },
                           Scheme = "oauth2",
                           Name = "Bearer",
                           In = ParameterLocation.Header
                       },
                       new List<string>()
                    }
                });
            });
            return services;
        }

        internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(t => { t.SwaggerEndpoint("/swagger/v1/swagger.json", "Jookli API"); });

            return app;
        }
    }
}
