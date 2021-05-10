using System;
using System.Collections.Generic;

namespace ZwiftSteero.Ble.Advertisement
{
    public class SteeroAdvertisement:IAdvertisement
    {
        private static readonly Guid sterzoUuid = Guid.Parse("347b0001-7635-408b-8918-8ff3949ce592");

        public Characteristic[] Characteristics
        {
            get
            {
                List<Characteristic> characteristics = new List<Characteristic>();

                characteristics.Add(new Characteristic("foo"));
                //TODO: add characteristics

                return characteristics.ToArray();
            }
        }
        public Guid UUID { get; } = sterzoUuid;
    }
}
