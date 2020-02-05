using System;

namespace HAProxyApi.Client.Models
{
    public class ShowInfoResponse : IShowInfoResponse
    {
        public string Raw { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int MaxConnections { get; set; }

        public int MaxSockets { get; set; }

        public TimeSpan Uptime { get; set; }

        public string Node { get; set; }

        public int UlimitN { get; set; }
    }
}