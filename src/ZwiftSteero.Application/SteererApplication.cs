using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ZwiftSteero.Application.Abstractions;
using ZwiftSteero.BleUDevice;

namespace ZwiftSteero.Application
{
    public class SteererApplication: ISteererApplication
    {
        
        private readonly ILogger<SteererApplication> logger;
        private readonly ISteeringService service;
        public SteererApplication(ILogger<SteererApplication> logger, 
        ISteeringService service)
        {
            this.logger = logger;
            this.service = service;
        }

        public async Task<bool> AdvertiseAsync(string port)
        {
            //make sure port is still available
            ISerialCommunicationPort device = new SerialCommunicationPort(port);



            return await Task.Run(() => true);  
        }
    }
}
