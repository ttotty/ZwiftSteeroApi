using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RJCP.IO.Ports;

using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Application.Mappers;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public class PortApplication: IPortApplication
    {
        private const int DefaultSearchMilliseconds = 30000;

        private readonly ILogger<PortApplication> logger;
        public PortApplication(ILogger<PortApplication> logger)
        {
            this.logger = logger;
        }

        public DeviceInfo Get(string port)
        {
            try
            {
                return new Device(port).Map();
            }
            catch(Exception ex)
            {
                logger.LogTrace(ex, $"Failed to get port: {port}");
                return null;
            }
        }

        public async Task<DeviceInfo[]> GetNewPortsAsync(int timeout = DefaultSearchMilliseconds)
        {
            DateTime stopLookingAt = DateTime.UtcNow.AddMilliseconds(timeout);
            List<Device> originalPorts = ListPorts();
            var recentPorts = new Dictionary<string, Device>();
            while(stopLookingAt >= DateTime.UtcNow
                  && (recentPorts.Values.Any(port => port.IsNew) == false) )
            {
                const int MillisecondsDelay = 500;

                IEnumerable<Device> justAdded = ListPorts().Where(existingPort => originalPorts.All(newPort => newPort.Port != existingPort.Port));
                foreach(Device newPort in justAdded)
                {
                    if(recentPorts.ContainsKey(newPort.Port))
                    {
                        if(recentPorts[newPort.Port].CheckAvailability() == false)
                        {
                            recentPorts.Remove(newPort.Port);
                        }
                    }
                    else
                    {
                        recentPorts.Add(newPort.Port, newPort);
                    }
                }

                await Task.Delay(MillisecondsDelay);
            }
            return recentPorts.Values.Where(port => port.IsNew).Select(p=> p.Map()).ToArray();
        }

        private List<Device> ListPorts()
        {
            var ports = new List<Device>();
            foreach (string port in SerialPortStream.GetPortNames())
            {
                try
                {
                    ports.Add(new Device(port));
                }
                catch(Exception)
                {
                    logger.LogWarning("Exceptions may occur if the port cannot be opened so log it in case this is the one we want");
                }
            }
            return ports;
        }

    }
}
