using System;
using System.Threading.Tasks;

namespace ZwiftSteero.Ble
{
    public interface ISteeringService
    {
        Task<bool> AdvertiseAsync(string port);
    }
}
