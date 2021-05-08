using Microsoft.Extensions.DependencyInjection;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection  AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton(new ServiceDescriptor(typeof(IPortApplication), typeof(PortApplication)));
            services.Add(new ServiceDescriptor(typeof(IPorts), typeof(Ports), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IChannel), typeof(ATChannel), ServiceLifetime.Transient));
           
            
            return services;
        }

    }
}
