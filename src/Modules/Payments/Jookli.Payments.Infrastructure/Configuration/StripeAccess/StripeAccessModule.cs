using Autofac;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.EventBus;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.Payments.Infrastructure.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Configuration.StripeAccess
{
    public class StripeAccessModule : Autofac.Module
    {
        private readonly string _stripeAccessKey;
        private readonly IStripeService _stripeService;

        public StripeAccessModule(string stripeService)
        {
            _stripeAccessKey = stripeService;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StripeService>()
              .As<IStripeService>()
              .WithParameter("stripeSecret", _stripeAccessKey)
              .InstancePerLifetimeScope();

            if (_stripeService != null)
            {
                builder.RegisterInstance(_stripeService).SingleInstance();
            }
            else
            {
                builder.RegisterType<StripeService>()
                    .As<IStripeService>()
                    .SingleInstance();
            }
        }
    }
}
