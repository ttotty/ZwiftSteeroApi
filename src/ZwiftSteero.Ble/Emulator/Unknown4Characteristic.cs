using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.Emulator
{
    public class Unknown4Characteristic : GattCharacteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0019-7635-408b-8918-8ff3949ce592");

        private static readonly GattProperty properties = GattProperty.Read;

        private static readonly GattDescriptorPermission permissions = GattDescriptorPermission.Read;  

        public Unknown4Characteristic(IService service) : base(
                service,
                uuid.ToString("N"),
                properties,
                permissions)
        { }
        public override string Description => "Unknown";

    }
}
