using System;

namespace ZwiftSteero.Ble.SerialCommunication
{
    public interface IAtAdapter
    {
        bool Connect(string portName);

        void StartAdvertising();

        void StartPeripheralMode();
    }
}
