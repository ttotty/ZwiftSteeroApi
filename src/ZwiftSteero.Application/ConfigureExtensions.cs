using Microsoft.Extensions.DependencyInjection;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection  AddApplicationServices(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IPortApplication), typeof(PortApplication), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPorts), typeof(Ports), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IChannel), typeof(ATChannel), ServiceLifetime.Transient));
            
            return services;
        }

    }
}
