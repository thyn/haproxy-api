using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HAProxyApi.Client.Models
{
	public class BackendServer
	{
		[Column("srv_name")]
		public string Name { get; set; }
		[Column("srv_id")]
		public string Id { get; set; }
		[Column("be_name")]
		public string BackendName { get; set; }
		[Column("be_id")]
		public string BackendId{ get; set; }
		[Column("srv_addr")]
		public string Ip { get; set; }
		[Column("srv_op_state")]
		public SrvState OperationalState { get; set; }
		[Column("srv_admin_state")]
		public SrvAdmin AdministrativeState { get; set; }
		[Column("srv_uweight")]
		public int CurrentWeight { get; set; }
		[Column("srv_iweight")]
		public int InitialWeight { get; set; }
		[Column("srv_time_since_last_change")]
		public int TimeSinceLastChange { get; set; }
		public TimeSpan GetTimeSinceLastChange() => TimeSpan.FromSeconds(TimeSinceLastChange);
		[Column("srv_check_status")]
		public int CheckStatus { get; set; }
		[Column("srv_check_result")]
		public ChkResult CheckResult { get; set; }
		[Column("srv_check_health")]
		public int CheckHealthCounter { get; set; }

		[Column("srv_check_state")]
		public ChkSt  CheckState { get; set; }
		[Column("srv_agent_state")]
		public ChkSt AgentState { get; set; }
		[Column("bk_f_forced_id")]
		public int BackendForcedId { get; set; }
		[Column("srv_f_forced_id")]
		public int ServerForcedId { get; set; }
	}
}