using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZwiftSteero.Ble.Advertisement;
using ZwiftSteero.Ble.BleuIo;

namespace ZwiftSteero.Ble.Emulator
{
    public class SteeringService: ISteeringService, IDisposable
    {
        private static readonly Guid sterzoUuid = Guid.Parse("347b0001-7635-408b-8918-8ff3949ce592");
        private readonly IBluetootLeAdapter adapter;

        public SteeringService(IBluetootLeAdapter adapter)
        {
            this.adapter = adapter;
        }

        public IEnumerable<GattCharacteristic> Characteristics
        {
            get
            {
                List<GattCharacteristic> characteristics = new List<GattCharacteristic>()
                {
                    new Unknown1Characteristic(this),
                    new Unknown2Characteristic(this),
                    new Unknown3Characteristic(this),
                    new Unknown4Characteristic(this),
                    new TxCharacteristic(this),
                    new RxCharacteristic(this),
                    new SteererCharacteristic(this)
                };

                return characteristics;
            }
        }

        public string ServiceName { get; } = "Steero!!!!";
        public string Uuid { get; } = sterzoUuid.ToString("N");

        public async Task<bool> AdvertiseAsync(string port)
        {
            //make sure port is still available
            adapter.Connect(port);

            //adapter.RegisterService(service);

            adapter.StartPeripheralMode();
            adapter.StartAdvertising(Uuid, ServiceName, Characteristics);

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
