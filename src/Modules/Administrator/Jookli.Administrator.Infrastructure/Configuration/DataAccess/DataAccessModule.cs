using Autofac;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace Jookli.Administrator.Infrastructure.Configuration.DataAccess
{
    internal class DataAccessModule : Autofac.Module
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;

        public DataAccessModule(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<AdministratorContext>();
                    dbContextOptionsBuilder.UseSqlServer(_connectionString, x => x.MigrationsHistoryTable("__AdministratorMigrationsHistory", "dbo"));

                   dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new AdministratorContext(dbContextOptionsBuilder.Options, _loggerFactory);
                })
                .AsSelf().As<DbContext>().InstancePerLifetimeScope();

            var infrastructureAssembly = typeof(AdministratorContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
