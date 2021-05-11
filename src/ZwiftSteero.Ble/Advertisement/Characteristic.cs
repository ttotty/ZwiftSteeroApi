using System;
using System.Text;

namespace ZwiftSteero.Ble.Advertisement
{
    public abstract class Characteristic
    {
        public Characteristic(string uuid): this(uuid, null) { }
        public Characteristic(string uuid, string value)
        {
            UUID = uuid;
            Value = value;
        }
        public virtual string UUID { get; protected set; }

        public virtual string Value { get; protected set; }

        public virtual string Description { get; protected set; }
}
}
