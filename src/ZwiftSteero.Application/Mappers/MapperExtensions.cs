using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application.Mappers
{

    internal static class MapperExtensions
    {
        public static DeviceResponse Map(this ISerialCommunicationPort portInfo)
        {
            return new DeviceResponse()
                {
                    Port = portInfo.Port
                };
        }
    }
}