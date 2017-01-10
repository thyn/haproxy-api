using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAProxyApi.Client.Models;
using HAProxyApi.Client.Parsers;
using NUnit.Framework;

namespace HAProxyApi.Client.Tests
{
	[TestFixture]
    public class ParseShowErrorResponseTest
    {
		public static IEnumerable<TestCaseData> ShowInfoTestCases
		{
			get
			{
				var test1 = ParseShowErrorTest1.Replace("\r", string.Empty);
				yield return new TestCaseData(test1, nameof(ShowErrorResponse.Raw)).Returns(test1);
				yield return new TestCaseData(test1, nameof(ShowErrorResponse.TotalEvents)).Returns(8);
				yield return
					new TestCaseData(test1, nameof(ShowErrorResponse.CapturedOn)).Returns(new DateTime(2017, 01, 10, 13, 51, 29, 449));
			}
		}

		[TestCaseSource(nameof(ShowInfoTestCases))]
		public object TestParse(string result, string propertyName)
		{

			var res = new ShowErrorParser().Parse(result);

			return res.GetType().GetProperty(propertyName).GetValue(res);
		}


		private const string ParseShowErrorTest1 = @" Total events captured on [10/Jan/2017:13:51:29.449] : 8
 
[10/Jan/2017:12:30:32.660] frontend http-in (#3): invalid request
  backend <NONE> (#-1), server <NONE> (#-1), event #7
  src 89.145.95.71:29138, session #376565, session flags 0x00000080
  HTTP msg state 26, msg flags 0x00000000, tx flags 0x00000000
  HTTP chunk len 0 bytes, HTTP body len 0 bytes
  buffer flags 0x00808002, out 0 bytes, total 590 bytes
  pending 590 bytes, wrapping at 32768, error at position 115:
 
  00000  GET /
  00313  Host: domain.com\r\n
  00334  User-Agent: Mozilla/5.0 (compatible; GrapeshotCrawler/2.0; +http://www
  00404+ .grapeshot.co.uk/crawler.php)\r\n
  00435  Accept-Encoding: deflate, gzip\r\n
  00467  Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.
  00537+ 8\r\n
  00540  Accept-Charset: utf-8,iso-8859-1;q=0.7,*;q=0.6\r\n
  00588  \r\n
";
	}
}
