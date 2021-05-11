using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public class Unknown3Characteristic: Characteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0014-7635-408b-8918-8ff3949ce592");
        private static readonly string description = "Unknown";

        public Unknown3Characteristic() : base(uuid.ToString("N")) { }

        public override string Description => description;

    }
}
