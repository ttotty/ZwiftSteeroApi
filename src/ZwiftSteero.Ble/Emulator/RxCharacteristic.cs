using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.Emulator
{
    public class RxCharacteristic: GattCharacteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0031-7635-408b-8918-8ff3949ce592");
        private static readonly GattProperty properties = GattProperty.Write;

        private static readonly GattDescriptorPermission permissions = GattDescriptorPermission.Read; 

        public RxCharacteristic(IService service) : base(
                service,
                uuid.ToString("N"),
                properties,
                permissions)
        { }
        public override string Description => "RX";
    }
}
