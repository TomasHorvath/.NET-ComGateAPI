using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Helpers
{

	public static class QueryExtensions
	{
		public static string ToQueryString(this NameValueCollection nvc)
		{
			IEnumerable<string> segments = from key in nvc.AllKeys
										   from value in nvc.GetValues(key)
										   select string.Format("{0}={1}",
										   WebUtility.UrlEncode(key),
										   WebUtility.UrlEncode(value));
			return "?" + string.Join("&", segments);
		}
	}
}
