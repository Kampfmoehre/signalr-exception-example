using Autofac;
using Microsoft.Extensions.Configuration;
using SignalRExceptionExample.Calculator;

namespace SignalRExceptionExample.Server
{
    public static class ServiceConfigurationExtensions
    {
        public static ContainerBuilder AddCalculatorServices(this ContainerBuilder builder)
        {
            builder.RegisterType<Calculator.Calculator>()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}