using System.Threading.Tasks;

namespace ZwiftSteero.Application.Abstractions
{
    public interface ISteererApplication
    {
        Task<bool> AdvertiseAsync(string port);
    }
}
