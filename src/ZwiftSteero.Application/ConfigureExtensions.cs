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
            services.AddTransient<IPorts,Ports>();
            services.AddTransient<IChannel,ATChannel>();
            services.AddSingleton<IBleServiceApplication, BleServiceApplication>();
            services.AddTransient<IBleService, BleService>();
            return services;
        }

    }
}
