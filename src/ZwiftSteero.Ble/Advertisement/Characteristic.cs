using System;
using System.Text;

namespace ZwiftSteero.Ble.Advertisement
{
    internal class Characteristic
    {
        private readonly string value;
        public Characteristic(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            var hexString = BitConverter.ToString(bytes);

            return hexString.Replace('-', ':').ToString();
        }
    }
}
