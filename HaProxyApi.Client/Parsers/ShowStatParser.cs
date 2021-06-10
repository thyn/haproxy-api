using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HAProxyApi.Client.Models;

namespace HAProxyApi.Client.Parsers
{
	public class ShowStatParser
	{
		public IEnumerable<IShowStatResponse> Parse(string rawStats)
		{
			const char csvFieldDelimiter = ',';

			return HaProxyClient.ParseResponse<ShowStatResponse>(rawStats, csvFieldDelimiter);
		}
	}
}