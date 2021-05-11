using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZwiftSteero.Ble.Advertisement;
using ZwiftSteero.Ble.BleuIo;

namespace ZwiftSteero.Ble
{
    public class SteeringService: ISteeringService, IDisposable
    {
        private static readonly Guid sterzoUuid = Guid.Parse("347b0001-7635-408b-8918-8ff3949ce592");
        private readonly IBleAdapter adapter;

        public SteeringService(IBleAdapter adapter)
        {
            this.adapter = adapter;
        }

        public Characteristic[] Characteristics
        {
            get
            {
                List<Characteristic> characteristics = new List<Characteristic>()
                {
                    new Unknown1Characteristic(),
                    new Unknown2Characteristic(),
                    new Unknown3Characteristic(),
                    new Unknown4Characteristic()
                };

                return characteristics.ToArray();
            }
        }

        public string ServiceName { get; } = "Terry Steero";
        public string ServiceUUID { get; } = sterzoUuid.ToString("N");

        public async Task<bool> AdvertiseAsync(string port)
        {
            //make sure port is still available
            adapter.Connect(port);

            //adapter.RegisterService(service);

            adapter.StartPeripheralMode();
            adapter.StartAdvertising(ServiceUUID, ServiceName, Characteristics);

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
