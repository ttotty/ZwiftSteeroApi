using Microsoft.Extensions.DependencyInjection;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection  AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPortApplication,PortApplication>();
            services.AddTransient<IPortDeviceManager,PortDeviceManager>();
            services.AddTransient<IChannel,ATChannel>();
            services.AddSingleton<ISteererApplication, SteererApplication>();
            services.AddTransient<IBluetoothAdapter, BluetoothAdapter>();
            services.AddTransient<ISteeringService, SteeringService>();
            return services;
        }

    }
}
