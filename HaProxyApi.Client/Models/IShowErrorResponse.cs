using System;

namespace HAProxyApi.Client.Models
{
    public interface IShowErrorResponse : IHAProxyResponse
    {
        DateTime? CapturedOn { get; }

        long? TotalEvents { get; }
    }
}