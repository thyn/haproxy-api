namespace HAProxyApi.Client.Models
{
	public enum SrvAdmin
	{
		SRV_ADMF_FMAINT = 0x01,       
		SRV_ADMF_IMAINT = 0x02,    
		SRV_ADMF_MAINT = 0x03,       
		SRV_ADMF_CMAINT = 0x04,      
		SRV_ADMF_FDRAIN = 0x08,        
		SRV_ADMF_IDRAIN = 0x10,        
		SRV_ADMF_DRAIN = 0x18,       
	};
}