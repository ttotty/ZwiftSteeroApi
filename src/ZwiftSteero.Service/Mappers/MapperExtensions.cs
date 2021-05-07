using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Service.Models;

namespace ZwiftSteero.Service.Mappers
{
    public static class MapperExtensions
    {
        public static Device Map(this IPortInfo portInfo)
        {
            return new Device()
                {
                    Port = portInfo.Port
                };
        }
    }
}