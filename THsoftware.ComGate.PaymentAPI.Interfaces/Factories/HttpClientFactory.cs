using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Enums;

namespace THsoftware.ComGate.PaymentAPI.Interfaces.Factories
{
	public class HttpClientFactory
	{
		public static HttpClient CreateHttpClient(ComGateHttpClient clientFlag, object param = null)
		{
			switch (clientFlag)
			{
				case ComGateHttpClient.HttpClient: return CreateBasicHttpClient(); break;
				case ComGateHttpClient.HttpClientWithFiddler: return CreateHttpClientWithFiddler(param); break;
				case ComGateHttpClient.HttpClientTimeout: return CreateHttpClientTimeOut(); break;
				default: return new HttpClient();
			}
		}

		private static HttpClient CreateBasicHttpClient()
		{
			return new HttpClient();
		}

		private static HttpClient CreateHttpClientWithFiddler(object param)
		{
			WebProxy proxy = new WebProxy("127.0.0.1:8888");
			try
			{
				proxy = param as WebProxy;
			}
			catch (Exception ex)
			{
				
			}

			
			HttpClientHandler httpClientHandler = new HttpClientHandler()
			{
				Proxy = proxy
			};
			return new HttpClient(httpClientHandler);
		
		}

		private static HttpClient CreateHttpClientTimeOut()
		{
			return new HttpClient();
		}
	}
}
