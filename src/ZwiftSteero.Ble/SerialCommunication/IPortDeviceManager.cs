using System.Collections.Generic;

namespace ZwiftSteero.Ble.SerialCommunication
{
    public interface IPortDeviceManager
    {
        List<SerialCommunicationPort> ActivePorts { get; }
    }
}
