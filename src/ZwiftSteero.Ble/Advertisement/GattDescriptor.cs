using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public class GattDescriptor
    {
        public GattDescriptor(Guid uuid, GattDescriptorPermission permissions)
        {
            Uuid = uuid;
            Permissions = permissions;
        }


        public Guid Uuid { get; }

        public GattDescriptorPermission Permissions { get; }
        //public GattCharacteristic Characteristic { get; set; }
    }
}
