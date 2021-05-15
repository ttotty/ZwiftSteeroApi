using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.Emulator
{
    public class SteererCharacteristic: GattCharacteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0030-7635-408b-8918-8ff3949ce592");
        private static readonly GattProperty properties = GattProperty.Notify;

        private static readonly GattDescriptorPermission permissions = GattDescriptorPermission.Read; 

        public SteererCharacteristic(IService service) : base(
                service,
                uuid.ToString("N"),
                properties,
                permissions)
        { }
        public override string Description => "notifications for steering angle";

    }
}
