using System;

namespace HAProxyApi.Client.Models
{
    public class ShowErrorResponse : IShowErrorResponse
    {
        public string Raw { get; set; }
        
        public DateTime? CapturedOn { get; set; }
        
        public long? TotalEvents { get; set; }
    }
}