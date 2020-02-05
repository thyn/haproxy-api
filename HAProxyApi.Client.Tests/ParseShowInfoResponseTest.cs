using System;
using System.Collections.Generic;
using HAProxyApi.Client.Models;
using HAProxyApi.Client.Parsers;
using NUnit.Framework;

namespace HAProxyApi.Client.Tests
{
	[TestFixture]
    public class ParseShowInfoResponseTest
    {
		public static IEnumerable<TestCaseData> ShowInfoTestCases
		{
			get
			{
				var test1 = ParseShowInfoResultTest1.Replace("\r", string.Empty);
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.Version)).Returns("1.7.1-d231fc-21");
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.Name)).Returns("HAProxy");
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.Node)).Returns("test.domain");
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.MaxConnections)).Returns(20000);
				yield return
					new TestCaseData(test1, nameof(ShowInfoResponse.ReleaseDate)).Returns(new DateTime(2017, 1, 5));
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.MaxSockets)).Returns(40059);
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.Uptime)).Returns(TimeSpan.FromSeconds(1500));
				yield return new TestCaseData(test1, nameof(ShowInfoResponse.UlimitN)).Returns(40059);
			}
		}

		[TestCaseSource(nameof(ShowInfoTestCases))]
		public object TestParse(string result, string propertyName)
		{

			var res = new ShowInfoParser().Parse(result);
			return res.GetType().GetProperty(propertyName).GetValue(res);
		}


		private const string ParseShowInfoResultTest1 = @" Name: HAProxy
Version: 1.7.1-d231fc-21
Release_date: 2017/01/05
Nbproc: 1
Process_num: 1
Pid: 9737
Uptime: 0d 0h25m00s
Uptime_sec: 1500
Memmax_MB: 0
PoolAlloc_MB: 1
PoolUsed_MB: 0
PoolFailed: 0
Ulimit-n: 40059
Maxsock: 40059
Maxconn: 20000
Hard_maxconn: 20000
CurrConns: 43
CumConns: 8995
CumReq: 50502
MaxSslConns: 0
CurrSslConns: 0
CumSslConns: 0
Maxpipes: 0
PipesUsed: 0
PipesFree: 0
ConnRate: 6
ConnRateLimit: 0
MaxConnRate: 23
SessRate: 6
SessRateLimit: 0
MaxSessRate: 23
SslRate: 0
SslRateLimit: 0
MaxSslRate: 0
SslFrontendKeyRate: 0
SslFrontendMaxKeyRate: 0
SslFrontendSessionReuse_pct: 0
SslBackendKeyRate: 0
SslBackendMaxKeyRate: 0
SslCacheLookups: 0
SslCacheMisses: 0
CompressBpsIn: 0
CompressBpsOut: 0
CompressBpsRateLim: 0
ZlibMemUsage: 0
MaxZlibMemUsage: 0
Tasks: 62
Run_queue: 1
Idle_pct: 100
node: test.domain";
	}
}
