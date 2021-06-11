namespace HAProxyApi.Client.Models
{
    public interface IShowStatResponse
    {
        string ProxyName { get; }
        
        string ServiceName { get; }
        
        long? ResponseTime { get; }
        
        long? Http1xxResponseCount { get; }
        
        long? Http2xxResponseCount { get; }
        
        long? Http3xxResponseCount { get; }
        
        long? Http4xxResponseCount { get; }
        
        long? Http5xxResponseCount { get; }
        
        long? HttpOtherResponseCount { get; }
        
        string Status { get; }
        
        long? CheckFailCount { get; }
        
        long? CheckDownCount { get; }
        
        long? TotalBackendDowntime { get; }
        
        long? ActiveServerCount { get; }
        
        long? BackupServerCount { get; }
        
        long? CurrentSessionCount { get; }
        
        long? MaxSessionCount { get; }
        
        long? SessionLimit { get; }
        
        long? SessionTotalCount { get; }
    }
}