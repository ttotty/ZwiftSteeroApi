using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application.Mappers
{

    internal static class MapperExtensions
    {
        public static DeviceResponse Map(this IDevice portInfo)
        {
            return new DeviceResponse()
                {
                    Port = portInfo.Port
                };
        }
    }
}