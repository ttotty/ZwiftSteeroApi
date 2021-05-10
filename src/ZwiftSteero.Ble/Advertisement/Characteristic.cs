using System;
using System.Text;

namespace ZwiftSteero.Ble.Advertisement
{
    public class Characteristic
    {
        private readonly string value;
        public Characteristic(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
