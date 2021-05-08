using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.Application.Mappers;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public class PortApplication: IPortApplication
    {
        private const int DefaultSearchMilliseconds = 30000;

        private readonly ILogger<PortApplication> logger;
        private readonly IPorts ports;
        private readonly IChannel channel;
        public PortApplication(ILogger<PortApplication> logger, 
        IPorts ports,
        IChannel channel)
        {
            this.logger = logger;
            this.ports = ports;
            this.channel = channel;
        }

        public async Task<DeviceInfo> AdvertiseAsync(string port)
        {
            IDevice device = new Device(port);



            return await Task.Run(() => new DeviceInfo());  
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
            List<Device> originalPorts = ports.ActivePorts;
            var recentPorts = new Dictionary<string, Device>();
            while(stopLookingAt >= DateTime.UtcNow
                  && (recentPorts.Values.Any(port => port.IsNew) == false) )
            {
                const int MillisecondsDelay = 500;

                IEnumerable<Device> justAdded = ports.ActivePorts.Where(existingPort => originalPorts.All(newPort => newPort.Port != existingPort.Port));
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
    }
}
