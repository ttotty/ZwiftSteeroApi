using System.Threading.Tasks;

namespace ZwiftSteero.Application.Abstractions
{
    public interface IBleServiceApplication
    {
        Task<bool> AdvertiseAsync(string port);
    }
}
