using Microsoft.Extensions.DependencyInjection;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Ble;

namespace ZwiftSteero.Application
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection  AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPortApplication,PortApplication>();
            services.AddSingleton<ISteererApplication, SteererApplication>();
            services.AddTransient<ISteeringService, SteeringService>();
            services.AddBleServices();
            return services;
        }

    }
}
