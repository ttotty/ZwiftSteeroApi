using System;

namespace ZwiftSteero.Ble.Advertisement
{
    public class Unknown1Characteristic: Characteristic
    {
        private static readonly Guid uuid = Guid.Parse("347b0012-7635-408b-8918-8ff3949ce592");
        private static readonly string description = "Get/set machine power state {'ON', 'OFF', 'UNKNOWN'}";

        public Unknown1Characteristic() : base(uuid.ToString("N")) { }

        public override string Description => description;

    }
}
