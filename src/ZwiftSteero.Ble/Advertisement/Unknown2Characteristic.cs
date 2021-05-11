using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public class Unknown2Characteristic: Characteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0013-7635-408b-8918-8ff3949ce592");
        private static readonly string description = "Unknown";

        public Unknown2Characteristic() : base(uuid.ToString("N")) { }

        public override string Description => description;

    }
}
