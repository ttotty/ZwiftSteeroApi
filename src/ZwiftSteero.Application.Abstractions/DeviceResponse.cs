using System;

namespace ZwiftSteero.Application.Abstractions
{
    public class DeviceResponse
    {
        public DeviceResponse(){}

        public string Port{ get; set;}

        public DateTime Processed
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public ConnectionState State{get; set;}
    }

}
