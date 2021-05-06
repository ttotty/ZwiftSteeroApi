using System.Threading.Tasks;

namespace ZwiftSteero.BleUDevice
{
    public interface IPortInfo
    {
        string Port{get;}
        string Description{get;set;}

        int BaudRate { get; set; }
        
        //Gets or sets the standard length of data bits per byte.
        int ByteSize { get; set; }
        
        int StopBits { get; set; }

        int ReadTimeout { get; set; }

        int WriteTimeout { get; set; }
        
        Task<IPortInfo[]> SearchForNewPortAsync(int timeout = 30000);
    }
}
