using System.Threading.Tasks;

namespace ZwiftSteero.Application.Abstractions
{

    public interface IPortApplication
    {
        DeviceResponse Get(string port);
        Task<DeviceResponse[]> GetNewPortsAsync(int timeout = 30000);
    }
}
