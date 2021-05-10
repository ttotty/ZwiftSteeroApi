using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public interface IAdvertisement
    {
        Guid UUID { get; }

        Characteristic[] Characteristics { get; }
    }
}
