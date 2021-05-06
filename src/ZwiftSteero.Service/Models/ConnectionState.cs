using System;
using System.Text.Json.Serialization;

namespace ZwiftSteero.Service.Models
{
  //  [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum ConnectionState
    {
        None = 0,
        Starting,
        Running,
        Failed,
        Stopping
    }
    
}
