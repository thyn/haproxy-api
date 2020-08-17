using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using HAProxyApi.Client.Models;
using HAProxyApi.Client.Parsers;
using LumenWorks.Framework.IO.Csv;

namespace HAProxyApi.Client
{
    public class HaProxyClient
    {
        private readonly string _hostNameOrIp;
        private readonly int _port;

        public HaProxyClient(string hostNameOrIp, int port)
        {
            _hostNameOrIp = hostNameOrIp;
            _port = port;
        }

        public string SendCommand(string command, bool readAnswer = true)
        {
            using var client = new TcpClient(_hostNameOrIp, _port);
            using var stream = client.GetStream();

            var bytes = Encoding.ASCII.GetBytes(command + "\n");

            stream.Write(bytes, 0, bytes.Length);
            stream.ReadTimeout = 250;

            if (!readAnswer)
            {
                return null;
            }

            var data = new byte[1024];

            using var ms = new MemoryStream();

            int numBytesRead;

            while ((numBytesRead = stream.Read(data, 0, data.Length)) > 0)
            {
                ms.Write(data, 0, numBytesRead);
            }

            var result = Encoding.ASCII.GetString(ms.ToArray(), 0, (int) ms.Length);

            return result;
        }

        private string ShowInfoRaw()
        {
            return SendCommand("show info", true);
        }

        public IShowInfoResponse ShowInfo()
        {
            return new ShowInfoParser().Parse(ShowInfoRaw());
        }

        public string ShowStatRaw()
        {
            return SendCommand("show stat", true);
        }

        public void ClearCounters()
        {
            SendCommand("clear counters", false);
        }
        
        public void ClearAllCounters()
        {
            SendCommand("clear counters all", false);
        }

        public IEnumerable<IShowStatResponse> ShowStat()
        {
            const char csvFieldDelimiter = ',';

            var rawStats = ShowStatRaw();

            return ParseResponse<ShowStatResponse>(rawStats, csvFieldDelimiter);
        }

        private string ShowErrorsRaw()
        {
            return SendCommand("show errors", true);
        }

        public IShowErrorResponse ShowErrors()
        {
            var response = ShowErrorsRaw();

            return new ShowErrorParser().Parse(response);
        }

        public IEnumerable<Backend> ShowBackends()
        {
            var resp = SendCommand("show backend");

            return ParseResponse<Backend>(resp);
        }

        public IEnumerable<BackendServer> ShowBackendServers(string backend = null)
        {
            var resp = SendCommand("show servers state " + backend);

            return ParseResponse<BackendServer>(resp);
        }

        public BackendServer DisableServer(string backend, string server)
        {
            SendCommand($"disable server {backend}/{server}");

            return ShowBackendServer(backend, server);
        }

        public BackendServer SetWeight(string backend, string server, int weight)
        {
            SendCommand($"set server {backend}/{server} weight {weight}", false);

            return ShowBackendServer(backend, server);
        }

        public BackendServer ShowBackendServer(string backend, string server)
        {
            return ShowBackendServers(backend)
                .FirstOrDefault(
                    x =>
                        string.Equals(x.Name, server, StringComparison.OrdinalIgnoreCase));
        }

        public BackendServer EnableServer(string backend, string server)
        {
            SendCommand($"enable server {backend}/{server}");
            var state =
                ShowBackendServers()
                    .FirstOrDefault(
                        x =>
                            string.Equals(backend, x.BackendName, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(x.Name, server, StringComparison.OrdinalIgnoreCase));

            return state;
        }

        private static IEnumerable<T> ParseResponse<T>(string raw, char delimiter = ' ')
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                yield break;
            }

            var indexOfSharp = raw.IndexOf("#", StringComparison.Ordinal);

            if (indexOfSharp == 0 && raw.Length == 1)
            {
                yield break;
            }

            if (indexOfSharp >= 0)
            {
                raw = raw.Substring(indexOfSharp + 1);
            }

            raw = raw.Trim();

            var reader = new CsvReader(new StringReader(raw), true, delimiter);
            
            while (reader.ReadNextRecord())
            {
                var item = Activator.CreateInstance<T>();

                foreach (var prop in item.GetType().GetProperties())
                {
                    var attr = prop.GetCustomAttribute<ColumnAttribute>();

                    if (attr != null)
                    {
                        if (reader[attr.Name] != null)
                        {
                            SetValue(prop, item, reader[attr.Name]);
                        }
                    }
                    else if (reader[prop.Name] != null)
                    {
                        SetValue(prop, item, reader[prop.Name]);
                    }
                }

                yield return item;
            }
        }

        private static void SetValue(PropertyInfo property, object target, string val)
        {
            if (property.PropertyType.IsEnum)
            {
                property.SetValue(target, int.Parse(val));

                return;
            }

            var type = Nullable.GetUnderlyingType(property.PropertyType);

            object safeValue;

            if (type is null)
            {
                safeValue = Convert.ChangeType(val, property.PropertyType);
            }
            else
            {
                safeValue = string.IsNullOrEmpty(val) ? null : Convert.ChangeType(val, type);
            }

            property.SetValue(target, safeValue);
        }
    }
}