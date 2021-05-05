using System;

namespace ZwiftSteero.Service.Models
{
    public class Device
    {
        public DateTime Processed 
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public string ComPort{ get; private set;}

        public ConnectionState State{get; set;}
    }
    
}
