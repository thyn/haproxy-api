# haproxy-api

Simple C# library to control HaProxy over TCP port.

# Supported methods

1. ShowErrors (string only)
2. ShowBackends
3. ShowBackendServers
4. SetWeight
5. DisableServer
6. EnableServer
7. ShowInfo (string only)

# Usage


	var client = new HaProxyClient("SERVER.DOMAIN.TLD", port);
	client.ShowErrors();
	client.ShowInfo();
	var servers = cli.ShowBackendServers();
	foreach (var backendServer in servers)
	{
		Console.WriteLine($"{backendServer.BackendName}/{backendServer.Name} is {backendServer.OperationalState}");
	}

sample result:

	backend1/server1 is SRV_ST_RUNNING
	backend1/server2 is SRV_ST_RUNNING
	backend2/server1 is SRV_ST_RUNNING
	backend2/server2 is SRV_ST_RUNNING
