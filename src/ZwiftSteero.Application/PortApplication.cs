using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RJCP.IO.Ports;

using ZwiftSteero.Application.Abstractions;
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

        public IPortInfo Get(string port)
        {
            try
            {
                return new PortInfo(port);
            }
            catch(Exception ex)
            {
                logger.LogTrace(ex, $"Failed to get port: {port}");
                return null;
            }
        }

        public async Task<IPortInfo[]> GetNewPortsAsync(int timeout = DefaultSearchMilliseconds)
        {
            DateTime stopLookingAt = DateTime.UtcNow.AddMilliseconds(timeout);
            List<PortInfo> originalPorts = ListPorts();
            var recentPorts = new Dictionary<string, PortInfo>();
            while(stopLookingAt >= DateTime.UtcNow
                  && (recentPorts.Values.Any(port => port.IsNew) == false) )
            {
                const int MillisecondsDelay = 500;

                IEnumerable<PortInfo> justAdded = ListPorts().Where(existingPort => originalPorts.All(newPort => newPort.Port != existingPort.Port));              
                foreach(PortInfo newPort in justAdded)
                {
                    if(recentPorts.ContainsKey(newPort.Port))
                    {
                        recentPorts[newPort.Port].Check();

                    }
                    else
                    {
                        recentPorts.Add(newPort.Port, newPort);
                    }
                }

                await Task.Delay(MillisecondsDelay);
            }
            return recentPorts.Values.Where(port => port.IsNew).ToArray();
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
                    logger.LogWarning("Exceptions may occur if the port cannot be opened so log it in case this is the one we want");
                }
            }
            return ports;
        }

    }
}
