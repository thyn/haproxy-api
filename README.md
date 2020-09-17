# HAProxy Api Client For .Net

[![AppVeyor](https://img.shields.io/appveyor/ci/thyn/haproxy-api.svg?style=plastic)]()
[![NuGet](https://img.shields.io/nuget/v/HAProxyApi.Client.svg)](https://www.nuget.org/packages/HAProxyApi.Client2)
[![Join the chat at https://gitter.im/haproxy-api](https://img.shields.io/gitter/room/haproxy-api/haproxy-api.svg)](https://gitter.im/haproxy-api)



Simple C# library to control HAProxy over TCP port.

# Installation

https://www.nuget.org/packages/HAProxyApi.Client2/

# HAProxy Config

To enable HAproxy stats api you should turn it on in global section of haproxy.conf. Do not forget to limit access to that port from global network.

	    stats socket ipv4@YOUR_HAPROXY_SERVER_IP:PORT level admin

# Supported methods

1. ShowErrors (header only)
2. ShowBackends
3. ShowBackendServers
4. SetWeight
5. DisableServer
6. EnableServer
7. ShowInfo (selected fields only)
8. ShowStat
9. ClearCounters
10. ClearAllCounters

# Usage

```c#
var client = new HaProxyClient("SERVER.DOMAIN.TLD", port);
string lastError = client.ShowErrors();
string info = client.ShowInfo();
var servers = cli.ShowBackendServers();
foreach (var backendServer in servers)
{
	Console.WriteLine($"{backendServer.BackendName}/{backendServer.Name} is {backendServer.OperationalState}");
}
```

sample result:

	backend1/server1 is SRV_ST_RUNNING
	backend1/server2 is SRV_ST_RUNNING
	backend2/server1 is SRV_ST_RUNNING
	backend2/server2 is SRV_ST_RUNNING
