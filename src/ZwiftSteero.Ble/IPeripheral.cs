using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble
{
    public interface IPeripheral
    {
        //IAdvertisement Advertisement { get; }
        Guid UUID { get; }
    }
}
