using System;

namespace HAProxyApi.Client.Models
{
    public interface IShowInfoResponse : IHAProxyResponse
    {
        string Name { get; }
        
        string Version { get; }
        
        DateTime? ReleaseDate { get; }
        
        int MaxConnections { get; }
        
        int MaxSockets { get; }
        
        TimeSpan Uptime { get; }
        
        string Node { get; }
        
        int UlimitN { get; }
    }
}