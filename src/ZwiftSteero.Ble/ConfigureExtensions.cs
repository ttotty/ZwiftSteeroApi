using Microsoft.Extensions.DependencyInjection;
using ZwiftSteero.Ble.Advertisement;
using ZwiftSteero.Ble.BleuIo;
using ZwiftSteero.Ble.SerialCommunication;

namespace ZwiftSteero.Ble
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection  AddBleServices(this IServiceCollection services)
        {
            services.AddTransient<IPortDeviceManager, PortDeviceManager>();
            services.AddTransient<IBluetootLeAdapter, BleuIoAdapter>();
            services.AddTransient<ISteeringService, SteeringService>();
            return services;
        }

    }
}
