using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public class Unknown3Characteristic: GattCharacteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0014-7635-408b-8918-8ff3949ce592");
        private static readonly GattProperty properties = GattProperty.Notify;
        private static readonly GattDescriptorPermission permissions = GattDescriptorPermission.Read;

        public Unknown3Characteristic(IService service) : base(
                service,
                uuid.ToString("N"),
                properties,
                permissions)
        { }
        public override string Description => "Unknown";


    }
}
