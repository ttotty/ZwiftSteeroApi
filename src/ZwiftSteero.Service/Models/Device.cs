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

        public string Port{ get; set;}

        public ConnectionState State{get; set;}
    }
    
}
