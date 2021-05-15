using System;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.Emulator
{
    public class Unknown1Characteristic: GattCharacteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0012-7635-408b-8918-8ff3949ce592");
        private static readonly GattProperty properties = GattProperty.Write;

        private static readonly GattDescriptorPermission permissions = GattDescriptorPermission.Read; 

        public Unknown1Characteristic(IService service) : base(
                service,
                uuid.ToString("N"),
                properties,
                permissions)
        { }
        public override string Description => "Get/set machine power state {'ON', 'OFF', 'UNKNOWN'}";


    }
}
