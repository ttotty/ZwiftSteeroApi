using System;

namespace ZwiftSteero.Service.Models
{
    public enum ConnectionState
    {
        None = 0,
        Starting,
        Running,
        Failed,
        Stopping
    }
    
}
