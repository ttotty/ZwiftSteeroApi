using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZwiftSteero.Ble.Advertisement;
using ZwiftSteero.Ble.SerialCommunication;

namespace ZwiftSteero.Ble
{
    public class SteeringService: ISteeringService, IBleService
    {
        private static readonly Guid SterzoUuid = Guid.Parse("347b0001-7635-408b-8918-8ff3949ce592");
        private readonly IAtAdapter adapter;
        public SteeringService(IAtAdapter adapter)
        {
            this.adapter = adapter;
        }
        public Guid UUID { get {return SterzoUuid; } }

        public async Task<bool> AdvertiseAsync(string port)
        {
            //make sure port is still available
            adapter.Connect(port);

            //adapter.RegisterService(service);

            adapter.StartPeripheralMode();
            adapter.StartAdvertising();
            

            return await Task.Run(() => true);  
        }

        Characteristic[] IBleService.Characteristics
        {
            get
            {
                List<Characteristic> characteristics = new List<Characteristic>();

                characteristics.Add(new Characteristic(UUID.ToString()));


                return characteristics.ToArray();
            }
        }
    }
}
