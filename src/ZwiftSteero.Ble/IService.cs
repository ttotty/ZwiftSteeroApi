using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble
{
    public interface IService
    {

        IEnumerable<GattCharacteristic> Characteristics { get; }
        string ServiceName { get; }
        string Uuid { get; }
        Task<bool> AdvertiseAsync(string port);
    }
}
