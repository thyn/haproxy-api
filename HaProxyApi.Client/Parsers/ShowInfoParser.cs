using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HAProxyApi.Client.Models;

namespace HAProxyApi.Client.Parsers
{
	public class ShowInfoParser
	{
		public IShowInfoResponse Parse(string rawShowInfoResult)
		{
			var propertyDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			if (!string.IsNullOrEmpty(rawShowInfoResult))
			{
				const string pattern = @"(?<key>[\w-]+): (?<value>.+)$";
				
				var matchResult = Regex.Matches(rawShowInfoResult, pattern, RegexOptions.Multiline);

				if (matchResult.Count != 0)
				{
					foreach (Match match in matchResult)
					{
						if (!match.Success)
						{
							continue;
						}

						propertyDictionary[match.Groups["key"].Value] = match.Groups["value"].Value;
					}
				}
			}
			
			return GetResult(rawShowInfoResult, propertyDictionary);
		}

		protected virtual ShowInfoResponse GetResult(string raw, Dictionary<string, string> properties)
		{
			if (string.IsNullOrWhiteSpace(raw) || properties == null || !properties.Any())
			{
				return new ShowInfoResponse
				{
					Raw = raw
				};
			}

			return new ShowInfoResponse
			{
				Name = GetValue<string>(properties, "Name"),
				Version = GetValue<string>(properties, "Version"),
				MaxConnections = GetValue<int>(properties, "Maxconn"),
				ReleaseDate = GetDateTime(properties, "Release_date"),
				MaxSockets = GetValue<int>(properties, "Maxsock"),
				Uptime = TimeSpan.FromSeconds(GetValue<int>(properties, "Uptime_sec")),
				Node = GetValue<string>(properties, "node"),
				UlimitN = GetValue<int>(properties, "Ulimit-n")
			};
		}

		private static T GetValue<T>(IReadOnlyDictionary<string, string> properties, string propertyName)
		{
			if (!properties.ContainsKey(propertyName))
			{
				return default;
			}

			return (T)Convert.ChangeType(properties[propertyName], typeof(T));
		}

		private static DateTime? GetDateTime(IReadOnlyDictionary<string, string> properties, string propertyName)
		{
			if (!properties.ContainsKey(propertyName))
			{
				return null;
			}

			return DateTime.ParseExact(properties[propertyName], "yyyy/MM/dd", CultureInfo.InvariantCulture);
		}
	}
}