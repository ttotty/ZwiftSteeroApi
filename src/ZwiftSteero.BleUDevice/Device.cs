using System;
using System.Linq;

using RJCP.IO.Ports;

namespace ZwiftSteero.BleUDevice
{
    public class Device: IDevice
    {

        public Device(string portName)
        {
            SerialPortStream port = new SerialPortStream(portName);
            Port = portName;
            BaudRate = port.BaudRate;
            ByteSize = port.DataBits;
            StopBits = Convert.ToInt32(port.StopBits);
            Description = SerialPortStream.GetPortDescriptions().First(p => p.Port == portName).Description;
            ReadTimeout = port.ReadTimeout;
            WriteTimeout = port.WriteTimeout;
            FirstSeenAt = DateTime.UtcNow;
        }

        public int BaudRate { get; private set; }

        //Gets or sets the standard length of data bits per byte.
        public int ByteSize { get; private set; }
        public string Description{get; private set;}

        public bool IsNew
        {
            get
            {
                //BleuIO USB uses the first 10 seconds to search for new firmware so
                //Port must be present for at least 15 seconds
                return LastSeenAt != null
                    && (LastSeenAt.Value - FirstSeenAt).TotalSeconds > 15;
            }
        }

        public string Port{get; private set;}

        public int ReadTimeout { get; private set; }

        public int StopBits { get; private set; }

        public int WriteTimeout { get; private set; }

        private DateTime FirstSeenAt{get; set;}

        private DateTime? LastSeenAt{get; set;}

        public bool CheckAvailability()
        {
            try
            {
                SerialPortStream port = new SerialPortStream(Port);
                LastSeenAt = DateTime.UtcNow;
            }
            catch
            {
                LastSeenAt = null;
            }
            return LastSeenAt.HasValue;
        }
    }
}