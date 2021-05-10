namespace ZwiftSteero.Ble.SerialCommunication
{
    public interface ISerialCommunicationPort
    {

        int BaudRate { get; }

        //Gets or sets the standard length of data bits per byte.
        int ByteSize { get; }
        string Description{get;}

        bool IsNew{get;}

        string Port{get;}

        int ReadTimeout { get; }

        int StopBits { get; }

        int WriteTimeout { get; }

        bool CheckAvailability();
    }
}
