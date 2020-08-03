namespace HAProxyApi.Client.Models
{
    public interface IShowStatResponse
    {
        string ProxyName { get; }
        
        string ServiceName { get; }
        
        int? ResponseTime { get; }
        
        int? Http1xxResponseCount { get; }
        
        int? Http2xxResponseCount { get; }
        
        int? Http3xxResponseCount { get; }
        
        int? Http4xxResponseCount { get; }
        
        int? Http5xxResponseCount { get; }
        
        int? HttpOtherResponseCount { get; }
        
        string Status { get; }
        
        int? CheckFailCount { get; }
        
        int? CheckDownCount { get; }
        
        int? TotalBackendDowntime { get; }
        
        int? ActiveServerCount { get; }
        
        int? BackupServerCount { get; }
        
        int? CurrentSessionCount { get; }
        
        int? MaxSessionCount { get; }
        
        int? SessionLimit { get; }
        
        int? SessionTotalCount { get; }
    }
}