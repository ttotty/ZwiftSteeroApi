using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble
{
    public interface IBleAdapter: IDisposable
    {
        bool Connect(string portName);

        void StartAdvertising(IAdvertisement advertisement);

        void StartPeripheralMode();
    }
}
