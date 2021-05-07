using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RJCP.IO.Ports;

namespace ZwiftSteero.BleUDevice
{
    public class PortInfo: IPortInfo
    {
        private const int DefaultSearchMilliseconds = 30000;

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

        private bool IsNewDevice
        {
            get
            {
                //BleuIO USB uses the first 10 seconds to search for new firmware so
                //Port must be present for at least 15 seconds
                return LastSeenAt != null 
                    && (LastSeenAt.Value - FirstSeenAt).TotalSeconds > 15; 
            }
        }
        public PortInfo()
        {

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
            FirstSeenAt = DateTime.Now;
        }

        public async Task<IPortInfo[]> SearchForNewPortAsync(int timeout = DefaultSearchMilliseconds)
        {
            DateTime stopLookingAt = DateTime.Now.AddMilliseconds(timeout);
            List<PortInfo> originalPorts = ListPorts();
            var recentPorts = new Dictionary<string, PortInfo>();
            while(stopLookingAt >= DateTime.Now
                  && (recentPorts.Values.Any(port => port.IsNewDevice) == false) )
            {
                const int MillisecondsDelay = 500;

                IEnumerable<PortInfo> justAdded = ListPorts().Where(existingPort => originalPorts.All(newPort => newPort.Port != existingPort.Port));              
                DateTime lastSeenAt = DateTime.Now;

                foreach(PortInfo newPort in justAdded)
                {
                    if(recentPorts.ContainsKey(newPort.Port))
                    {
                        recentPorts[newPort.Port].LastSeenAt = lastSeenAt;

                    }
                    else
                    {
                        recentPorts.Add(newPort.Port, newPort);
                    }
                }

                await Task.Delay(MillisecondsDelay);
            }
            return recentPorts.Values.Where(port => port.IsNewDevice).ToArray();
        }

        private List<PortInfo> ListPorts()
        {
            var ports = new List<PortInfo>();
            foreach (string port in SerialPortStream.GetPortNames()) 
            {
                try
                {
                    ports.Add(new PortInfo(port));
                }
                catch(Exception)
                {
                    
                    //TODO: Exceptions may occur if the port cannot be opened so log it in case this is the one we want
                }
            }
            return ports;
        }

    }
}