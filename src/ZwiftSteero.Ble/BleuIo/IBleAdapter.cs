using System;
using System.Collections.Generic;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.BleuIo
{
    public interface IBleAdapter: IDisposable
    {
        bool Connect(string portName);

        void StartAdvertising(string serviceUUID,
                              string serviceName,
                              IEnumerable<Characteristic> characteristics);

        void StartPeripheralMode();
    }
}
