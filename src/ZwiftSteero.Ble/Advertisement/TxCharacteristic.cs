using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public class TxCharacteristic: GattCharacteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0032-7635-408b-8918-8ff3949ce592");

        private static readonly GattProperty properties = GattProperty.Indicate;

        private static readonly GattDescriptorPermission permissions = GattDescriptorPermission.Read; 

        public TxCharacteristic(IService service) : base(
                service,
                uuid.ToString("N"),
                properties,
                permissions)
        { }
        public override string Description => "TX";
    }
}
