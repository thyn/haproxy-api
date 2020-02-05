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
            var result = new ShowErrorResponse
            {
                Raw = rawShowErrorResult,
            };

            if (string.IsNullOrEmpty(rawShowErrorResult))
            {
                return result;
            }

            const string pattern = @"Total events captured on \[(?<date>.+)\].+: (?<total>\d+)";
            
            var match = Regex.Match(rawShowErrorResult, pattern, RegexOptions.Multiline);

            if (match.Success)
            {
                const string dateFormat = @"dd/MMM/yyyy:HH:mm:ss.fff";
                
                result.CapturedOn = DateTime.ParseExact(match.Groups["date"].Value, dateFormat, CultureInfo.InvariantCulture);
                
                result.TotalEvents = int.Parse(match.Groups["total"].Value);
            }

            return result;
        }
    }
}