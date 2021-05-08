using System.Threading.Tasks;

namespace ZwiftSteero.Application.Abstractions
{

    public interface IPortApplication
    {
        Task<DeviceInfo> ConnectAsync(string port);
        DeviceInfo Get(string port);
        Task<DeviceInfo[]> GetNewPortsAsync(int timeout = 30000);
    }
}
