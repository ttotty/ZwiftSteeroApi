using System;

namespace ZwiftSteero.Ble.Advertisement
{
    [Flags]
    public enum GAPDataType
    {
        Flags =    0x01, //AD Flags (Mandatory for advertising data)
        CustomServiceUuid = 0x06, //128-bit Service UUIDs, more available
        CompleteServiceUuidList = 0x07, //128-bit Service UUIDs, complete list
        ShortName = 0x08, //Shortened Local name
        CompleteName = 0x09, //Complete Local Name
        TxPower = 0x0A //Tx Power in dBm
    }
}
