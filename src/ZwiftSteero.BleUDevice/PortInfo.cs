using System;
using System.Linq;

using RJCP.IO.Ports;

using ZwiftSteero.Application.Abstractions;

namespace ZwiftSteero.BleUDevice
{
    public class PortInfo: IPortInfo
    {

        public string Port{get;private set;}
        public string Description{get;set;}

        public int BaudRate { get; set; }
        
        //Gets or sets the standard length of data bits per byte.
        public int ByteSize { get; set; }
        
        public int StopBits { get; set; }

        public int ReadTimeout { get; set; }

        public int WriteTimeout { get; set; }

        private DateTime FirstSeenAt{get;set;}

        private DateTime? LastSeenAt{get;set;}

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

        public bool Check()
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

        public PortInfo(string portName)
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
    }
}