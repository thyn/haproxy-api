namespace HAProxyApi.Client.Models
{
	public enum ChkSt
	{
		CHK_ST_INPROGRESS = 0x0001,
		CHK_ST_CONFIGURED = 0x0002,
		CHK_ST_ENABLED = 0x0004,
		CHK_ST_PAUSED = 0x0008,
		CHK_ST_AGENT = 0x0010
	}
}