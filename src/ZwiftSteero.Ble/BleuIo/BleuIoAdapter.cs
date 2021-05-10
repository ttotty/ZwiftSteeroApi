using System;
using System.Text;
using Microsoft.Extensions.Logging;
using RJCP.IO.Ports;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble.BleuIo
{
    public class BleuIoAdapter:IBleAdapter
    {

        private const int DefaultWriteTimeout = 2000;
        private readonly ILogger<BleuIoAdapter> logger;

        private SerialPortStream port;

        public BleuIoAdapter(ILogger<BleuIoAdapter> logger)
        {
            this.logger = logger;
        }

        public bool Connect(string portName)
        {
            if(port == null)
            {
                port = new SerialPortStream(portName);
                SetupPort(port);
                if (port.IsOpen == false)
                {
                    port.Open();
                }
            }
            else if (portName != port.PortName)
            {
                //port can't be changed
                throw new ArgumentException("Argument cannot be changed", nameof(portName));
            }

            if(port.IsOpen == false)
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            if(port != null)
            {
                if(port.IsOpen)
                {
                    port.Close();
                }
                port.Dispose();
            }
        }

        //ATDS: Turns auto discovery of services when connecting
        //ATE: Turn echo on/off
        //ATI: Device information query. Returns firmware version, hardware type and unique organization identifier
        //ATR: Trigger platform reset
        //**AT+ADVDATA: Sets or queries the advertising data

        public void StartAdvertising(IAdvertisement advertisement)
        {
            Write("AT+ADVDATA=");
            WriteHex(advertisement.UUID.ToString("N"));
            WriteNewLine();

            foreach (Characteristic characteristic in advertisement.Characteristics)
            {
                WriteHex(characteristic.ToString());
                WriteHex(" ");
            }
            WriteNewLine();

            WriteLine($"AT+ADVSTART"); //=(mode);(18);(intv_max);(time_ms)");
        }

        //AT+ADVSTOP: Stops advertising
        //AT+ADVRESP: Sets or queries scan response data
        //AT+FINDSCANDATA: Scans for all advertising/response data
        //AT+GAPDISCONNECTALL: Disconnects from all connected peer Bluetooth devices
        //**AT+GAPPAIR: Starts a pairing
        //AT+GAPUNPAIR: Unpair paired devices
        //AT+GETCONN: Gets a list of currently connected devices
        public void StartPeripheralMode()
        {
            //peripheral mode can't have any connections to switch over so disconnect first to make sure
            WriteLine("AT+GAPDISCONNECTALL");
            WriteLine("AT+PERIPHERAL");
        }

        //AT+SCANTARGET: Scan a target device. Displaying it's advertising and response data
        //******AT+SETNOTI: Enable notification for selected characteristic
        //******AT+SPSSEND: Send a message or data via the SPS profile
        //AT+TARGETCONN: Setting or querying the connection index to use as the targeted connection

        private static void SetupPort(SerialPortStream port)
        {
            //port.BaudRate = 57600;
            //port.Parity = Parity.None;
            //port.StopBits = StopBits.One;
            //port.DataBits = 8;
            //port.ReadTimeout = SerialPortStream.InfiniteTimeout;
            port.WriteTimeout = DefaultWriteTimeout;
        }

        private void Write(string text)
        {
            logger.LogInformation($"PORT.Write(\"{text}\")");

            byte[] buffer = Encoding.UTF8.GetBytes(text + '\r');
            port.Write(buffer, 0, buffer.Length);
        }

        private void WriteHex(string text)
        {
            string hex = BitConverter.ToString(Encoding.UTF8.GetBytes(text)).Replace('-',':');
            byte[] buffer = Encoding.UTF8.GetBytes(hex);
            logger.LogInformation($"PORT.WriteHex(\"{hex}\") text=\"{text}\"");

            port.Write(buffer, 0, buffer.Length);

        }
        private void WriteLine(string text)
        {
            Write(text);
            WriteNewLine();
        }
        private void WriteNewLine()
        {
            logger.LogInformation("PORT.NewLine");
            Write('\r'.ToString());
            port.Flush();
        }
    }
}
