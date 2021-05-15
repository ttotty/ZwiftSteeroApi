using System.Collections.Generic;
using ZwiftSteero.Ble.Extensions;

namespace ZwiftSteero.Ble.Advertisement
{
    public abstract class GattCharacteristic
    {
        public GattCharacteristic(
            IService service,
            string uuid,
            GattProperty properties,
            GattDescriptorPermission permissions)
        {
            Service = service;
            Uuid = uuid;
            Property = properties;
            Permission = permissions;
        }

        public virtual string Description{ get; protected set; }
        public bool CanBeNotified => (Property & GattProperty.Notify) != 0;

        public bool CanRead => (Property & GattProperty.Read) != 0;

        public bool CanWrite => (Property & GattProperty.Write) != 0;

        public GattDescriptorPermission Permission { get; private set; }

        public IEnumerable<GattDescriptorPermission> Permissions
        {
            get
            {
                return Permission.GetUniqueFlags<GattDescriptorPermission>();
            }
        }

        public GattProperty Property { get; private set; }

        public IEnumerable<GattProperty> Properties
        {
            get
            {
                return Property.GetUniqueFlags<GattProperty>();
            }
        }

        public string ServiceUuid { get { return Service.Uuid; } }

        public IService Service { get; private set; }

        public string Uuid { get; private set; }
    }
}
