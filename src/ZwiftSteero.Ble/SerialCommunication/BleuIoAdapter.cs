using System;
using RJCP.IO.Ports;

namespace ZwiftSteero.Ble.SerialCommunication
{
    public class BleuIoAdapter:IAtAdapter, IDisposable
    {
        private const int DefaultWriteTimeout = 2000;

        private SerialPortStream port;

        public BleuIoAdapter()
        {
        }

        public bool Connect(string portName)
        {
            if(port == null)
            {
                port = new SerialPortStream(portName);
                SetupPort(port);
                port.Open();
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
            throw new NotImplementedException();
        }

        //ATDS: Turns auto discovery of services when connecting
        //ATE: Turn echo on/off
        //ATI: Device information query. Returns firmware version, hardware type and unique organization identifier
        //ATR: Trigger platform reset
        //**AT+ADVDATA: Sets or queries the advertising data

        public void StartAdvertising()
        {
            port.Write($"AT+ADVSTART=");

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
            port.WriteLine("AT+GAPDISCONNECTALL");
            port.WriteLine("AT+PERIPHERAL");
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
    }
}
