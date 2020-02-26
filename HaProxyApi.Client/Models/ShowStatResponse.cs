using System.ComponentModel;

namespace HAProxyApi.Client.Models
{
    public class ShowStatResponse : IShowStatResponse
    {
        [Column("pxname")]
        public string ProxyName { get; set; }

        [Column("svname")]
        public string ServiceName { get; set; }

        [Column("rtime")]
        public int? ResponseTime { get; set; }

        [Column("hrsp_1xx")]
        public int? Http1xxResponseCount { get; set; }

        [Column("hrsp_2xx")]
        public int? Http2xxResponseCount { get; set; }

        [Column("hrsp_3xx")]
        public int? Http3xxResponseCount { get; set; }

        [Column("hrsp_4xx")]
        public int? Http4xxResponseCount { get; set; }

        [Column("hrsp_5xx")]
        public int? Http5xxResponseCount { get; set; }
        
        [Column("hrsp_other")]
        public int? HttpOtherResponseCount { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("chkfail")]
        public int? CheckFailCount { get; set; }

        [Column("chkdown")]
        public int? CheckDownCount { get; set; }

        [Column("downtime")]
        public int? TotalBackendDowntime { get; set; }

        [Column("act")]
        public int? ActiveServerCount { get; set; }
        
        [Column("bck")]
        public int? BackupServerCount { get; set; }
    }
}