using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public class BleServiceApplication: IBleServiceApplication
    {
        
        private readonly ILogger<BleServiceApplication> logger;
        private readonly IPorts ports;
        private readonly IChannel channel;
        public BleServiceApplication(ILogger<BleServiceApplication> logger, 
        IPorts ports,
        IChannel channel)
        {
            this.logger = logger;
            this.ports = ports;
            this.channel = channel;
        }

        public async Task<bool> AdvertiseAsync(string port)
        {
            IDevice device = new Device(port);



            return await Task.Run(() => true);  
        }
    }
}
