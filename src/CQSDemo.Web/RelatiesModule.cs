using System;
using Autofac;
using CQSDemo.Relaties;
using CQSDemo.Relaties.Implementation;
using CQSDemo.ServiceBus;
using Microsoft.Framework.Logging;

namespace CQSDemo.Web
{
    public class RelatiesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceBusClient>().Named<IServiceBusClient>("serviceBusClient");
            builder.RegisterType<RelatieConverter>().As<IRelatieConverter>();
            builder.RegisterType<RelatieOpBSNQuery>().As<IRelatieOpBSNQuery>();
            builder.Register(container => {
                var factory = new LoggerFactory { MinimumLevel = LogLevel.Debug};
                return factory.AddConsole(LogLevel.Debug).CreateLogger("Console");
            }).As<ILogger>();

            builder.RegisterDecorator<IServiceBusClient>((decorator, inner) => new ServiceBusClientLogger(inner, decorator.Resolve<ILogger>()), fromKey: "serviceBusClient");
        }
    }
}