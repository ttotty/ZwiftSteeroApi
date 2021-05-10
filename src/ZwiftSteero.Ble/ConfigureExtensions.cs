using Microsoft.Extensions.DependencyInjection;
using ZwiftSteero.Ble.SerialCommunication;

namespace ZwiftSteero.Ble
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection  AddBleServices(this IServiceCollection services)
        {
            services.AddTransient<IPortDeviceManager, PortDeviceManager>();
            services.AddTransient<IAtAdapter, BleuIoAdapter>();
            services.AddTransient<ISteeringService, SteeringService>();
            return services;
        }

    }
}
