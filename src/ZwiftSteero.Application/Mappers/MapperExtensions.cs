using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application.Mappers
{

    internal static class MapperExtensions
    {
        public static DeviceInfo Map(this IDevice portInfo)
        {
            return new DeviceInfo()
                {
                    Port = portInfo.Port
                };
        }
    }
}