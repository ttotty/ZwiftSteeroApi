namespace ZwiftSteero.Application.Abstractions
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

        bool IsNew{get;}

        bool Check();
    }
}
