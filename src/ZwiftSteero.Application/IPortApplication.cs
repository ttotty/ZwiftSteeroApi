using System.Threading.Tasks;
using ZwiftSteero.Application.Abstractions;

namespace ZwiftSteero.Application
{
    public interface IPortApplication
    {        
        Task<IPortInfo[]> GetNewPortsAsync(int timeout = 30000);
        IPortInfo Get(string port);
    }
}
