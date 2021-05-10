using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RJCP.IO.Ports;

namespace ZwiftSteero.Ble.SerialCommunication
{
    public class PortDeviceManager: IPortDeviceManager
    {
        private readonly ILogger<PortDeviceManager> logger;

        public PortDeviceManager(ILogger<PortDeviceManager> logger)
        {
            this.logger = logger;
        }

        public List<SerialCommunicationPort> ActivePorts{
            get
            {
                var ports = new List<SerialCommunicationPort>();
                foreach (string port in SerialPortStream.GetPortNames())
                {
                    try
                    {
                        ports.Add(new SerialCommunicationPort(port));
                    }
                    catch (Exception)
                    {
                        logger.LogWarning("Exceptions may occur if the port cannot be opened so log it in case this is the one we want");
                    }
                }
                return ports;
            }
        }
    }
}
