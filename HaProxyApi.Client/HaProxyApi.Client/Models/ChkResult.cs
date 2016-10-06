namespace HAProxyApi.Client.Models
{
	public enum ChkResult
	{
		CHK_RES_UNKNOWN = 0,            
		CHK_RES_NEUTRAL,             
		CHK_RES_FAILED,                 
		CHK_RES_PASSED,                 
		CHK_RES_CONDPASS,               
	};
}