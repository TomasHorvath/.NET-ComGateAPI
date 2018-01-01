using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;

namespace THsoftware.ComGate.PaymentAPI.Interfaces
{
	public interface IComGateRequestBuilder
	{
		/// <summary>
		/// Create CreatePaymentRequest
		/// </summary>
		/// <param name="payment"></param>
		/// <param name="payer"></param>
		/// <param name="urlEndpoint"></param>
		/// <param name="lang"></param>
		/// <param name="embedded"></param>
		/// <param name="initRecurring"></param>
		/// <param name="preauth"></param>
		/// <param name="verification"></param>
		/// <param name="prepareOnly"></param>
		/// <returns></returns>
		PaymentRequest CreatePaymentRequest(
			BaseComGatePayment payment,
			Payer payer,
			Core.Domain.Enums.Lang lang = Core.Domain.Enums.Lang.cs
			);

		/// <summary>
		/// Create request for supported payments methods
		/// </summary>
		/// <returns></returns>
		PaymentMethodsRequest CreatePaymentMethodsRequest();

	}
}
