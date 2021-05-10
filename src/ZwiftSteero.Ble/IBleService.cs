using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble
{
    internal interface IBleService
    {
        Guid UUID { get; }

        Characteristic[] Characteristics { get; }
    }
}
