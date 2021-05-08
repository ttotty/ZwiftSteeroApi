using System.Collections.Generic;

namespace ZwiftSteero.BleUDevice
{
    public interface IPortDeviceManager
    {
        List<SerialCommunicationPort> ActivePorts { get; }
    }
}
