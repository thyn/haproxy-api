using System;
using System.Globalization;
using System.Text.RegularExpressions;
using HAProxyApi.Client.Models;

namespace HAProxyApi.Client.Parsers
{
	public class ShowErrorParser
	{
		public IShowErrorResponse Parse(string rawShowErrorResult)
		{
			var result = new ShowErrorResponse()
			{
				Raw = rawShowErrorResult,
			};
			if (!string.IsNullOrEmpty(rawShowErrorResult))
			{
				var match = Regex.Match(rawShowErrorResult, @"Total events captured on \[(?<date>.+)\].+: (?<total>\d+)",
					RegexOptions.Multiline);

				if (match.Success)
				{
					result.CapturedOn = DateTime.ParseExact(match.Groups["date"].Value, @"dd/MMM/yyyy:HH:mm:ss.fff",
						CultureInfo.InvariantCulture);
					result.TotalEvents = Int32.Parse(match.Groups["total"].Value);
				}

			}
			return result;
		}
	}
}