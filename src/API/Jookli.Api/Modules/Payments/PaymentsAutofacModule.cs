using Autofac;
using Jookli.Payments.Application.Contracts;
using Jookli.Payments.Infrastructure;

namespace Jookli.Api.Modules.Payments
{
    public class PaymentsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PaymentsModule>()
                .As<IPaymentsModule>()
                .InstancePerLifetimeScope();
        }
    }
}
