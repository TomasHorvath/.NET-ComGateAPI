using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;

namespace THsoftware.ComGate.PaymentAPI.Interfaces
{
	public interface IComGateContentSerializer
	{
		/// <summary>
		/// create http content
		/// </summary>
		FormUrlEncodedContent Serialize<T>(T request);

		/// <summary>
		///  Create response from url params
		/// </summary>
		/// <param name="url"></param>
		ApiResponse<T> Deserialize<T>(string responseContent);

		
		


	}
}
