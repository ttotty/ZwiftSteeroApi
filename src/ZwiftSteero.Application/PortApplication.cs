using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Application.Mappers;
using ZwiftSteero.Ble.SerialCommunication;

namespace ZwiftSteero.Application
{
    public class PortApplication: IPortApplication
    {
        private const int DefaultSearchMilliseconds = 30000;

        private readonly ILogger<PortApplication> logger;
        private readonly IPortDeviceManager ports;
        public PortApplication(ILogger<PortApplication> logger, 
        IPortDeviceManager ports)
        {
            this.logger = logger;
            this.ports = ports;
        }

        public DeviceResponse Get(string port)
        {
            try
            {
                return new SerialCommunicationPort(port).Map();
            }
            catch(Exception ex)
            {
                logger.LogTrace(ex, $"Failed to get port: {port}");
                return null;
            }
        }

        public async Task<DeviceResponse[]> GetNewPortsAsync(int timeout = DefaultSearchMilliseconds)
        {
            DateTime stopLookingAt = DateTime.UtcNow.AddMilliseconds(timeout);
            List<SerialCommunicationPort> originalPorts = ports.ActivePorts;
            var recentPorts = new Dictionary<string, SerialCommunicationPort>();
            while(stopLookingAt >= DateTime.UtcNow
                  && (recentPorts.Values.Any(port => port.IsNew) == false) )
            {
                const int MillisecondsDelay = 500;

                IEnumerable<SerialCommunicationPort> justAdded = ports.ActivePorts.Where(existingPort => originalPorts.All(newPort => newPort.Port != existingPort.Port));
                foreach(SerialCommunicationPort newPort in justAdded)
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
    }
}
