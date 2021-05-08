using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RJCP.IO.Ports;

namespace ZwiftSteero.BleUDevice
{
    public class Ports: IPorts
    {
        private readonly ILogger<Ports> logger;

        public Ports(ILogger<Ports> logger)
        {
            this.logger = logger;
        }
        
        public List<Device> ActivePorts{
            get
            {
                var ports = new List<Device>();
                foreach (string port in SerialPortStream.GetPortNames())
                {
                    try
                    {
                        ports.Add(new Device(port));
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
