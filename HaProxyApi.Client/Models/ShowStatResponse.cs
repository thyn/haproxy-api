namespace HAProxyApi.Client.Models
{
    public class ShowStatResponse : IShowStatResponse
    {
        [Column("pxname")]
        public string ProxyName { get; set; }

        [Column("svname")]
        public string ServiceName { get; set; }

        [Column("rtime")]
        public long? ResponseTime { get; set; }

        [Column("hrsp_1xx")]
        public long? Http1xxResponseCount { get; set; }

        [Column("hrsp_2xx")]
        public long? Http2xxResponseCount { get; set; }

        [Column("hrsp_3xx")]
        public long? Http3xxResponseCount { get; set; }

        [Column("hrsp_4xx")]
        public long? Http4xxResponseCount { get; set; }

        [Column("hrsp_5xx")]
        public long? Http5xxResponseCount { get; set; }
        
        [Column("hrsp_other")]
        public long? HttpOtherResponseCount { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("chkfail")]
        public long? CheckFailCount { get; set; }

        [Column("chkdown")]
        public long? CheckDownCount { get; set; }

        [Column("downtime")]
        public long? TotalBackendDowntime { get; set; }

        [Column("act")]
        public long? ActiveServerCount { get; set; }
        
        [Column("bck")]
        public long? BackupServerCount { get; set; }
        
        [Column("scur")]
        public long? CurrentSessionCount { get; set; }
        
        [Column("smax")]
        public long? MaxSessionCount { get; set; }

        [Column("slim")]
        public long? SessionLimit { get; set; }
        
        [Column("stot")]
        public long? SessionTotalCount { get; set; }
    }
}