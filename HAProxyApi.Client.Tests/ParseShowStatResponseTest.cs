using System;
using System.Collections.Generic;
using System.Linq;
using HAProxyApi.Client.Models;
using HAProxyApi.Client.Parsers;
using NUnit.Framework;

namespace HAProxyApi.Client.Tests
{
	[TestFixture]
    public class ParseShowStatResponseTest
    {
		[Test]
		public void ParseStatResponse_Always_ShouldHandleNumbersLargerThanInt32()
		{
			Assert.DoesNotThrow(() =>
			{
				var response = new ShowStatParser().Parse(ParseShowStatResultTest).ToList();
			}, "Parse method threw an exception with large numbers", null);
		}

		private const string ParseShowStatResultTest =
@"# pxname,svname,qcur,qmax,scur,smax,slim,stot,bin,bout,dreq,dresp,ereq,econ,eresp,wretr,wredis,status,weight,act,bck,chkfail,chkdown,lastchg,downtime,qlimit,pid,iid,sid,throttle,lbtot,tracked,type,rate,rate_lim,rate_max,check_status,check_code,check_duration,hrsp_1xx,hrsp_2xx,hrsp_3xx,hrsp_4xx,hrsp_5xx,hrsp_other,hanafail,req_rate,req_rate_max,req_tot,cli_abrt,srv_abrt,comp_in,comp_out,comp_byp,comp_rsp,lastsess,last_chk,last_agt,qtime,ctime,rtime,ttime,agent_status,agent_code,agent_duration,check_desc,agent_desc,check_rise,check_fall,check_health,agent_rise,agent_fall,agent_health,addr,cookie,mode,algo,conn_rate,conn_rate_max,conn_tot,intercepted,dcon,dses,wrew,connect,reuse,cache_lookups,cache_hits,srv_icur,src_ilim,qtime_max,ctime_max,rtime_max,ttime_max,eint,idle_conn_cur,safe_conn_cur,used_conn_cur,need_conn_est,
http-in,FRONTEND,,,4058,8940,30000,124006383,7137062112866,25489157882162,0,0,4501748,,,,,OPEN,,,,,,,,,1,2,0,,,,0,41,0,1309,,,,0,2152625847,482614963,49153289,234165,4052496,,1077,6922,2688681028,,,0,0,0,0,,,,,,,,,,,,,,,,,,,,,http,,47,1320,127831804,0,0,0,0,,,0,0,,,,,,,0,,,,,
be_prod,server01,0,0,8,2908,10000,491872955,1310555778171,2997838897762,,0,,11,3023,11853,7,UP,10,1,0,573,212,8457,4027,,1,3,1,,491861119,,2,270,,1300,L7OK,200,6,8614,367998417,113809798,9996729,31000,0,,,,491844558,2461180,299,,,,,0,,,0,1,37,2838,,,,Layer7 check passed,,3,2,4,,,,10.177.64.5:80,s5,http,,,,,,,,0,491872972,0,,,0,,0,707,770410,782928,0,0,0,8,2909,
be_prod,server02,0,0,13,3984,10000,511957705,1277664013648,3108993070675,,0,,7,3533,10249,8,UP,10,1,0,565,206,8379,3969,,1,3,2,,511947540,,2,275,,1698,L7OK,200,6,0,401018690,102324400,8555967,28872,0,,,,511927929,2223580,271,,,,,0,,,0,1,47,2144,,,,Layer7 check passed,,3,2,4,,,,10.177.64.44:80,s6,http,,,,,,,,0,511957789,0,,,0,,100,316,645973,730953,0,0,0,13,3984,
be_prod,server03,0,0,4,2065,10000,488006599,1166511192750,2999227204801,,0,,3,3399,11586,3,UP,10,1,0,736,226,7929,4669,,1,3,3,,487995026,,2,182,,1496,L7OK,200,5,0,383167065,95654735,9128018,27612,0,,,,487977430,2122243,66,,,,,0,,,0,2,45,3355,,,,Layer7 check passed,,3,2,4,,,,10.177.64.57:80,s7,http,,,,,,,,0,488006612,0,,,0,,0,216,407823,407823,0,0,0,4,2066,
be_prod,server04,0,0,4,3294,10000,472112525,1184535805165,2752942310561,,0,,8,3068,7081,18,UP,10,1,0,811,227,8235,4797,,1,3,4,,472105571,,2,135,,1341,L7OK,200,6,35,374627962,89270350,8166204,26129,0,,,,472090680,1809121,101,,,,,0,,,0,0,53,2844,,,,Layer7 check passed,,3,2,4,,,,10.177.64.38:80,s8,http,,,,,,,,0,472112652,0,,,0,,0,301,316774,409132,0,0,0,4,3295,
be_prod,server05,0,0,5,3246,10000,372984718,879626429303,2271985118683,,0,,6,3407,3588,0,UP,10,1,0,592,214,8166,4132,,1,3,5,,372981131,,2,130,,1438,L7OK,200,5,1942,283997813,81437181,7504160,23700,0,,,,372964796,1686041,193,,,,,0,,,0,0,51,2808,,,,Layer7 check passed,,3,2,4,,,,10.177.64.61:80,s9,http,,,,,,,,0,372984719,0,,,0,,0,204,887214,893708,0,0,0,5,3246,
be_prod,BACKEND,0,0,34,7963,20000,2340692445,5825443536098,14130992530591,0,0,,26860,16430,44357,36,UP,50,5,0,,7,1892354,113,,1,3,0,,2336890387,,1,994,,6844,,,,0,1810809947,482496464,43351533,179806,3854661,,,,2340692411,14077434,930,0,0,0,0,0,,,0,1,48,2910,,,,,,,,,,,,,,http,source,,,,,,,0,2336934744,0,0,0,,,100,707,887214,893708,0,,,,,
";
	}
}
