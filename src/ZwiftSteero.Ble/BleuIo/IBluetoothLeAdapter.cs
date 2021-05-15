using System;
using System.Collections.Generic;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.BleuIo
{
    public interface IBluetootLeAdapter: IDisposable
    {
        bool Connect(string portName);

        void StartAdvertising(string serviceUUID,
                              string serviceName,
                              IEnumerable<GattCharacteristic> characteristics);

        void StartPeripheralMode();
    }
}
