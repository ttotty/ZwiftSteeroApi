using System;
using System.Threading.Tasks;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble
{
    public class SteeringService: ISteeringService, IPeripheral, IDisposable
    {
        private readonly IBleAdapter adapter;
        private readonly IAdvertisement steeroAdvertisement;
        public SteeringService(IBleAdapter adapter, IAdvertisement steeroAdvertisement)
        {
            this.adapter = adapter;
            this.steeroAdvertisement = steeroAdvertisement;
        }
        public Guid UUID { get {return steeroAdvertisement.UUID; } }

        public async Task<bool> AdvertiseAsync(string port)
        {
            //make sure port is still available
            adapter.Connect(port);

            //adapter.RegisterService(service);

            adapter.StartPeripheralMode();
            adapter.StartAdvertising(steeroAdvertisement);            

            return await Task.Run(() => true);  
        }

        public void Dispose()
        {
            if(adapter != null)
            {
                adapter.Dispose();
            }
        }
    }
}
