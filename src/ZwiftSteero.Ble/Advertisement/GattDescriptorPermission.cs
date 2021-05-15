using System;

namespace ZwiftSteero.Ble.Advertisement
{
    [Flags]
    public enum GattDescriptorPermission
    {
        Read = 1,
        Write = 16,
    }
}
