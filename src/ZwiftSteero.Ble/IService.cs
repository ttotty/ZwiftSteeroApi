using System;
using System.Threading.Tasks;
using ZwiftSteero.Ble.Advertisement;

namespace ZwiftSteero.Ble
{
    public interface IService
    {

        Characteristic[] Characteristics { get; }
        string ServiceName { get; }
        string ServiceUUID { get; }
        Task<bool> AdvertiseAsync(string port);
    }
}
