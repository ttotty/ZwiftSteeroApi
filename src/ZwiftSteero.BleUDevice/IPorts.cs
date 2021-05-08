using System.Collections.Generic;

namespace ZwiftSteero.BleUDevice
{
    public interface IPorts
    {
        List<Device> ActivePorts { get; }
    }
}
